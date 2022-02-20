namespace SolidSavings.Web.Models
{
    using System;

    public class Outcome
    {
        public decimal Netto { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public Guid Id { get; set; }

        public Guid UserId { get; set; }
    }
}