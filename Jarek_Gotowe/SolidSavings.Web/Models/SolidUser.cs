namespace SolidSavings.Web.DataAccess
{
    using System;

    using SolidSavings.Web.Models.Enums;

    public class SolidUser
    {
        public Guid ID { get; set; }

        public UserRegistrationType UserRegistrationType { get; set; }

        public string Name { get; set; }
    }
}