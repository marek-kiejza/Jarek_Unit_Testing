namespace SolidSavings.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using SolidSavings.Web.Logic;
    using SolidSavings.Web.Models;

    public class AuthorizationController : Controller
    {
        private IUserBusiness userBusiness;

        public AuthorizationController(IUserBusiness userBusiness)
        {
            this.userBusiness = userBusiness;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginDto dto)
        {
            if (this.ModelState.IsValid)
            {
                this.userBusiness.LoginUser(dto.Username);
                return this.RedirectToAction("Incomes", "Home");
            }

            return this.RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Register(RegisterDto dto)
        {
            if (this.ModelState.IsValid)
            {
                if (this.userBusiness.RegisterNewUser(dto.Username, dto.RegistrationType))
                {
                    return this.RedirectToAction("Login", "Authorization");
                }
            }

            return this.RedirectToAction("Register");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            this.userBusiness.LogoutUser();
            return this.RedirectToAction("Login");
        }
    }
}