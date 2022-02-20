namespace SolidSavings.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

    using SolidSavings.Web.Infrastructure;
    using SolidSavings.Web.Logic;
    using SolidSavings.Web.Models;

    [SolidAuthorization]
    public class HomeController : Controller
    {
        private IBusiness business;
        private IUserBusiness userBusiness;

        private ISolidExporter exporter;

        public HomeController(IBusiness business, IUserBusiness userBusiness, ISolidExporter exporter)
        {
            this.business = business;
            this.userBusiness = userBusiness;
            this.exporter = exporter;
        }

        [HttpGet]
        public IActionResult AddIncome()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult AddIncome(AddIncomeDto dto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("AddIncome");
            }

            if (this.userBusiness.IsDemoUser())
            {
                return this.View("AddIncome");
            }

            if (this.userBusiness.IsFreeUser())
            {
                if (!this.business.CanAddNewIncome())
                {
                    return this.View("AddIncome");
                }
            }

            var income = new Income { Id = Guid.NewGuid(), Netto = dto.IncomeNetto, Year = dto.Year, Month = dto.Month, UserId = SolidSession.CurrentUserId };
            this.business.AddIncomeToCurrentUser(income);
            return this.RedirectToAction("Incomes");
        }

        [HttpGet]
        public IActionResult AddOutcome()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult AddOutcome(AddOutcomeDto dto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("AddOutcome");
            }

            if (this.userBusiness.IsDemoUser())
            {
                return this.View("AddOutcome");
            }

            if (this.userBusiness.IsFreeUser())
            {
                if (!this.business.CanAddNewOutcome())
                {
                    return this.View("AddOutcome");
                }
            }

            var outcome = new Outcome { Id = Guid.NewGuid(), Netto = dto.OutcomeNetto, Year = dto.Year, Month = dto.Month, UserId = SolidSession.CurrentUserId };
            this.business.AddOutcomeToCurrentUser(outcome);
            return this.RedirectToAction("Outcomes");
        }

        [HttpGet]
        public IActionResult Circle()
        {
            var incomes = this.business.GetCurrentUserCircleIncomes();
            var outcomes = this.business.GetCurrentUserCircleOutcomes();

            var circleChartModel = new ChartModel { Incomes = incomes, Outcomes = outcomes, };
            return this.View("Circle", circleChartModel);
        }
        
        [HttpGet]
        public IActionResult Export(SolidExportType exportType)
        {
            if (this.exporter.CanExport(exportType, SolidSession.CurrentUserType) == false)
            {
                return this.RedirectToAction("Exports");
            }

            var ms = this.exporter.Export(exportType);
            var applicationType = this.exporter.GetApplicationType(exportType);
            return this.File(ms, applicationType);
        }

        [HttpGet]
        public IActionResult Exports()
        {
            return this.View("Exports");
        }

        [HttpPost]
        public IActionResult ImportJson(IFormFile jsonImport)
        {
            string str = (new StreamReader(jsonImport.OpenReadStream())).ReadToEnd();
            var j = JsonConvert.DeserializeAnonymousType(
                str,
                new { Incomes = new List<Income>(), Outcomes = new List<Outcome>() });

            j.Incomes.ForEach(i => i.UserId = SolidSession.CurrentUserId);
            j.Outcomes.ForEach(o => o.UserId = SolidSession.CurrentUserId);

            this.business.SetCurrentUserIncomes(j.Incomes);
            this.business.SetCurrentUserOutcomes(j.Outcomes);

            return this.RedirectToAction("Incomes");
        }

        [HttpGet]
        public IActionResult Imports()
        {
            return this.View("Imports");
        }

        public IActionResult Incomes()
        {
            var incomes = this.business.GetCurrentUserIncomesGrouped();
            return this.View("Incomes", incomes);
        }

        [HttpGet]
        public IActionResult Line()
        {
            var incomes = this.business.GetCurrentUserLineIncomes();
            var outcomes = this.business.GetCurrentUserLineOutcomes();

            var lineChartModel = new ChartModel { Incomes = incomes, Outcomes = outcomes, };
            return this.View("Line", lineChartModel);
        }

        [HttpGet]
        public IActionResult ListIncomes()
        {
            var incomes = this.business.GetCurrentUserIncomesOrdered();
            return this.View("ListIncomes", incomes);
        }

        [HttpGet]
        public IActionResult ListOutcomes()
        {
            var outcomes = this.business.GetCurrentUserOutcomesOrdered();
            return this.View("ListOutcomes", outcomes);
        }

        public IActionResult Outcomes()
        {
            var outcomes = this.business.GetCurrentUserOutcomesGrouped();
            return this.View("Outcomes", outcomes);
        }

        [HttpGet]
        public IActionResult Radar()
        {
            var incomes = this.business.GetCurrentUserRadarIncomes();
            var outcomes = this.business.GetCurrentUserRadarOutcomes();

            var radarChartModel = new ChartModel { Incomes = incomes, Outcomes = outcomes, };

            return this.View("Radar", radarChartModel);
        }

        [HttpGet]
        public IActionResult RemoveIncome(Guid id)
        {
            if (this.userBusiness.IsDemoUser())
            {
                return this.RedirectToAction("ListIncomes");
            }

            this.business.RemoveIncomeFromCurrentUser(id);
            return this.RedirectToAction("ListIncomes");
        }

        [HttpGet]
        public IActionResult RemoveOutcome(Guid id)
        {
            if (this.userBusiness.IsDemoUser())
            {
                return this.RedirectToAction("ListOutcomes");
            }

            this.business.RemoveOutcomeFromCurrentUser(id);
            return this.RedirectToAction("ListOutcomes");
        }

        public IActionResult Reports()
        {
            return this.View("Reports");
        }
    }
}