namespace SolidSavings.Web.Infrastructure
{
    using System;

    using SolidSavings.Web.Models.Enums;

    public class SolidSession
    {
        public static Guid CurrentUserId { get; set; }

        public static string CurrentUserName { get; set; }

        public static UserRegistrationType CurrentUserType { get; set; }
    }
}