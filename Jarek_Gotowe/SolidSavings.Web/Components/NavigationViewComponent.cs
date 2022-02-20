using Microsoft.AspNetCore.Mvc;
using SolidSavings.Web.Controllers;

namespace SolidSavings.Web.Components
{
    using SolidSavings.Web.Models.Enums;

    public class NavigationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ApplicationState state)
        {
            return this.View(state);
        }
    }

    public class LoginLogoViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ApplicationState state)
        {
            return this.View(state);
        }
    }
}
