namespace SolidSavings.Web.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SolidSavings.Web.DataAccess;
    using SolidSavings.Web.Infrastructure;
    using SolidSavings.Web.Models;

    public class Business : IBusiness
    {
        private readonly ISolidDatabase database;

        public Business(ISolidDatabase database)
        {
            this.database = database;
        }

        public const int MaximumOperationsAllowedForFreeUser = 12;

        public bool CanAddNewOutcome()
        {
            return this.database.GetOutcomes(SolidSession.CurrentUserId).Count < MaximumOperationsAllowedForFreeUser;
        }

        public bool CanAddNewIncome()
        {
            return this.database.GetIncomes(SolidSession.CurrentUserId).Count < MaximumOperationsAllowedForFreeUser;
        }

        public void AddIncomeToCurrentUser(Income income)
        {
            this.database.AddIncome(income);
        }

        public void AddOutcomeToCurrentUser(Outcome outcome)
        {
            this.database.AddOutcome(outcome);
        }

        public List<Income> GetCurrentUserCircleIncomes()
        {
            return this.GetReportIncomes();
        }

        public List<Outcome> GetCurrentUserCircleOutcomes()
        {
            return this.GetReportOutcomes();

        }

        public List<Income> GetCurrentUserLineIncomes()
        {
            return this.GetReportIncomes();
        }

        public List<Outcome> GetCurrentUserLineOutcomes()
        {
            return this.GetReportOutcomes();
        }

        public List<Income> GetCurrentUserIncomes()
        {
            return this.database.GetIncomes(SolidSession.CurrentUserId);
        }

        public List<Outcome> GetCurrentUserOutcomes()
        {
            return this.database.GetOutcomes(SolidSession.CurrentUserId);
        }

        public void SetCurrentUserIncomes(List<Income> incomes)
        {
            this.database.SetIncomes(incomes);
        }

        public void SetCurrentUserOutcomes(List<Outcome> outcomes)
        {
            this.database.SetOutcomes(outcomes);
        }

        public List<Income> GetCurrentUserIncomesOrdered()
        {
            return this.database.GetIncomes(SolidSession.CurrentUserId)
                .OrderBy(i => i.Year)
                .ThenBy(i => i.Month).ThenByDescending(i => i.Month).ToList();
        }

        public List<Outcome> GetCurrentUserOutcomesOrdered()
        {
            return this.database.GetOutcomes(SolidSession.CurrentUserId)
                .OrderBy(i => i.Year)
                .ThenBy(i => i.Month).ThenByDescending(i => i.Month).ToList();
        }

        public List<Outcome> GetCurrentUserOutcomesGrouped()
        {
            return this.database.GetOutcomes(SolidSession.CurrentUserId)
                .GroupBy(i => new { Y = i.Year, M = i.Month }, i => i.Netto)
                .Select(g => new Outcome { Year = g.Key.Y, Month = g.Key.M, Netto = g.Sum(s => s) })
                .OrderBy(i => i.Year).ThenBy(i => i.Month).ThenByDescending(i => i.Netto).ToList();
        }

        public List<Income> GetCurrentUserIncomesGrouped()
        {
            return this.database.GetIncomes(SolidSession.CurrentUserId)
                .GroupBy(i => new { Y = i.Year, M = i.Month }, i => i.Netto)
                .Select(g => new Income { Year = g.Key.Y, Month = g.Key.M, Netto = g.Sum(s => s) }).OrderBy(i => i.Year)
                .ThenBy(i => i.Month).ThenByDescending(i => i.Netto).ToList();
        }

        public List<Income> GetCurrentUserRadarIncomes()
        {
            return this.GetReportIncomes();
        }

        public List<Outcome> GetCurrentUserRadarOutcomes()
        {
            return this.GetReportOutcomes();
        }

        public void RemoveIncomeFromCurrentUser(Guid id)
        {
            this.database.RemoveIncome(id);
        }

        public void RemoveOutcomeFromCurrentUser(Guid id)
        {
            this.database.RemoveOutcome(id);
        }

        public int this_is_just_a_test(List<int> p)
        {
            return p.Count;
        }

        private List<Income> GetReportIncomes()
        {
            return this.database.GetIncomes(SolidSession.CurrentUserId)
                .GroupBy(i => new { Y = i.Year, M = i.Month }, i => i.Netto)
                .Select(g => new Income { Year = g.Key.Y, Month = g.Key.M, Netto = g.Sum(s => s) }).OrderBy(i => i.Year)
                .ThenBy(i => i.Month).ThenByDescending(i => i.Netto).ToList();
        }

        private List<Outcome> GetReportOutcomes()
        {
            return this.database.GetOutcomes(SolidSession.CurrentUserId)
                .GroupBy(i => new { Y = i.Year, M = i.Month }, i => i.Netto)
                .Select(g => new Outcome { Year = g.Key.Y, Month = g.Key.M, Netto = g.Sum(s => s) })
                .OrderBy(i => i.Year).ThenBy(i => i.Month).ThenByDescending(i => i.Netto).ToList();
        }
    }
}