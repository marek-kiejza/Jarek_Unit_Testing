using System.Globalization;
using System.Linq;
using System.Text;

namespace SolidSavings.Web.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SolidSavings.Web.DataAccess;
    using SolidSavings.Web.Infrastructure;
    using SolidSavings.Web.Models;
    using SolidSavings.Web.Models.Enums;

    public class UserBusiness : IUserBusiness
    {
        private readonly ISolidDatabase database;

        public UserBusiness(ISolidDatabase database)
        {
            this.database = database;
        }

        public bool IsDemoUser()
        {
            return SolidSession.CurrentUserType == UserRegistrationType.Demo;
        }

        public bool IsFreeUser()
        {
            return SolidSession.CurrentUserType == UserRegistrationType.Free;
        }

        public bool IsPaidUser()
        {
            return SolidSession.CurrentUserType != UserRegistrationType.Paid;
        }

        public bool RegisterNewUser(string usernameToRegister, UserRegistrationType userType)
        {
            if (IsUsernameAlreadyTaken(usernameToRegister))
            {
                return false;
            }

            var newUserId = Guid.NewGuid();

            var solidUser =
                new SolidUser { ID = newUserId, UserRegistrationType = userType, Name = usernameToRegister };

            this.database.AddUser(solidUser);

            SolidSession.CurrentUserName = usernameToRegister;
            SolidSession.CurrentUserId = newUserId;
            SolidSession.CurrentUserType = userType;

            if (userType == UserRegistrationType.Demo)
            {
                Create45IncomesForUser(newUserId);
                Create5OutcomesForUser(newUserId);
            }

            return true;
        }

        public bool IsUsernameAlreadyTaken(string usernameToRegister)
        {
            return this.database
                       .GetUsers()
                       .Any(v => usernameToRegister.RemoveDiacritics().Equals(v.Name.RemoveDiacritics(), StringComparison.InvariantCultureIgnoreCase));
        }

        public void Create5OutcomesForUser(Guid newUserId)
        {
            var outcomes = new List<Outcome>();

            outcomes.Add(new Outcome {Id = Guid.NewGuid(), Year = 2000, Month = 10, Netto = 12000, UserId = newUserId});
            outcomes.Add(new Outcome {Id = Guid.NewGuid(), Year = 2000, Month = 10, Netto = 2000, UserId = newUserId});
            outcomes.Add(new Outcome {Id = Guid.NewGuid(), Year = 2000, Month = 11, Netto = 22000, UserId = newUserId});
            outcomes.Add(new Outcome {Id = Guid.NewGuid(), Year = 2000, Month = 12, Netto = 2000, UserId = newUserId});
            outcomes.Add(new Outcome {Id = Guid.NewGuid(), Year = 2000, Month = 2, Netto = 2000, UserId = newUserId});

            this.database.SetOutcomes(outcomes);
        }

        public void Create45IncomesForUser(Guid newUserId)
        {
            var incomes = new List<Income>();

            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2000, Month = 10, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2000, Month = 10, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2000, Month = 11, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2000, Month = 12, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2000, Month = 12, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 4, Netto = 4000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 5, Netto = 2055, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2000, Month = 1, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2000, Month = 2, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2000, Month = 3, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 1, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 6, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 1, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 2, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2000, Month = 6, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2000, Month = 8, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2000, Month = 9, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 9, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 3, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 5, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 6, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 6, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 6, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 11, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 4, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 9, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 9, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 9, Netto = 2030, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 10, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 10, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 1, Netto = 21000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 2, Netto = 2020, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 11, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 12, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2000, Month = 4, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2000, Month = 5, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2000, Month = 6, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 6, Netto = 1000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 7, Netto = 6000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2002, Month = 8, Netto = 2500, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2000, Month = 9, Netto = 2000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 9, Netto = 2040, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 10, Netto = 2001, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 11, Netto = 12000, UserId = newUserId});
            incomes.Add(new Income {Id = Guid.NewGuid(), Year = 2001, Month = 12, Netto = 0, UserId = newUserId});

            this.database.SetIncomes(incomes);
        }

        public void LoginUser(string username)
        {
            var userToLogin = this.database.GetUsers()
                .Single(f => username.Equals(f.Name, StringComparison.InvariantCultureIgnoreCase));

            SolidSession.CurrentUserName = userToLogin.Name;
            SolidSession.CurrentUserId = userToLogin.ID;
        }

        public void LogoutUser()
        {
            SolidSession.CurrentUserName = string.Empty;
            SolidSession.CurrentUserId = Guid.Empty;
        }
    }
}


public static class Extensions
{
    public static string RemoveDiacritics(this string text)
    {
        return string.Concat(
            text.Normalize(NormalizationForm.FormD)
                .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) !=
                             UnicodeCategory.NonSpacingMark)
        ).Normalize(NormalizationForm.FormC);
    }

}