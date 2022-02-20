namespace SolidSavings.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AddIncomeDto
    {
        [Required]
        public decimal IncomeNetto { get; set; }

        [Required]
        public int Year { get; set; }
        
        [Required]
        public int Month { get; set; }
    }
}