namespace SolidSavings.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AddOutcomeDto
    {
        [Required]
        public decimal OutcomeNetto { get; set; }

        [Required]
        public int Year { get; set; }
        
        [Required]
        public int Month { get; set; }
    }
}