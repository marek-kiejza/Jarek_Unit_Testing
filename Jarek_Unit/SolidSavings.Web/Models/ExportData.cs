namespace SolidSavings.Web.Controllers
{
    using System.Collections.Generic;

    using SolidSavings.Web.Models;

    public class ExportData
    {
        public List<Income> Incomes { get; set; }
        public List<Outcome> Outcomes { get; set; }
    }
}