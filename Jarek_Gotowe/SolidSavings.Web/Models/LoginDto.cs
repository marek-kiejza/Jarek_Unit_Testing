namespace SolidSavings.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    using SolidSavings.Web.Models.Enums;

    public class LoginDto
    {
        [Required]
        public string Username { get; set; }
    }

    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Range(1, 3)]
        public UserRegistrationType RegistrationType { get; set; }
    }
}