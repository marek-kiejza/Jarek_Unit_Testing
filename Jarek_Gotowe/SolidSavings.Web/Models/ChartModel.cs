namespace SolidSavings.Web.Models
{
    using System.Collections.Generic;

    public class ChartModel
    {
        public List<Income> Incomes { get; set; }

        public List<Outcome> Outcomes { get; set; }
    }
}