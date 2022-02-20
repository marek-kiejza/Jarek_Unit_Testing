namespace SolidSavings.Web.Infrastructure
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    using SolidSavings.Web.Controllers;
    using SolidSavings.Web.DataAccess;

    public class SolidAuthorizationAttribute : Attribute, IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (SolidSession.CurrentUserId == Guid.Empty)
            {
                context.Result = new RedirectToActionResult("Login", "Authorization", null);
            }
        }
    }
}