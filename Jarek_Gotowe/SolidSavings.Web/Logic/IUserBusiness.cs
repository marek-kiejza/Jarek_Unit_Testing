namespace SolidSavings.Web.Logic
{
    using SolidSavings.Web.Models.Enums;

    public interface IUserBusiness
    {
        bool IsDemoUser();

        bool IsFreeUser();

        bool IsPaidUser();

        bool RegisterNewUser(string usernameToRegister, UserRegistrationType userType);

        void LoginUser(string username);

        void LogoutUser();
    }
}