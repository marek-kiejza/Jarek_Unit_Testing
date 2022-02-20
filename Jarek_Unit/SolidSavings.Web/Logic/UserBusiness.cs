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
            if (this.database.GetUsers().Any(v => usernameToRegister.Equals(v.Name, StringComparison.InvariantCultureIgnoreCase)))
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
                var incomes = new List<Income>();

                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2000, Month = 10, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2000, Month = 10, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2000, Month = 11, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2000, Month = 12, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2000, Month = 12, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 4, Netto = 4000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 5, Netto = 2055, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2000, Month = 1, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2000, Month = 2, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2000, Month = 3, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 1, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 6, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 1, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 2, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2000, Month = 6, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2000, Month = 8, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2000, Month = 9, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 9, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 3, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 5, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 6, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 6, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 6, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 11, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 4, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 9, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 9, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 9, Netto = 2030, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 10, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 10, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 1, Netto = 21000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 2, Netto = 2020, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 11, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 12, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2000, Month = 4, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2000, Month = 5, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2000, Month = 6, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 6, Netto = 1000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 7, Netto = 6000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2002, Month = 8, Netto = 2500, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2000, Month = 9, Netto = 2000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 9, Netto = 2040, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 10, Netto = 2001, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 11, Netto = 12000, UserId = newUserId });
                incomes.Add(new Income { Id = Guid.NewGuid(), Year = 2001, Month = 12, Netto = 0, UserId = newUserId });

                this.database.SetIncomes(incomes);

                var outcomes = new List<Outcome>();

                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2000, Month = 10, Netto = 12000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2000, Month = 10, Netto = 2000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2000, Month = 11, Netto = 22000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2000, Month = 12, Netto = 2000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2000, Month = 12, Netto = 42000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 4, Netto = 4000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 5, Netto = 2055, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2000, Month = 1, Netto = 62000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2000, Month = 2, Netto = 2000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2000, Month = 3, Netto = 2000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 1, Netto = 42000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 6, Netto = 2000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 1, Netto = 2000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 2, Netto = 22000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2000, Month = 6, Netto = 2000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2000, Month = 8, Netto = 2000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2000, Month = 9, Netto = 72000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 9, Netto = 2000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 3, Netto = 2000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 5, Netto = 72000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 6, Netto = 2000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 6, Netto = 52000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 6, Netto = 2000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 11, Netto = 2000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 4, Netto = 2000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 9, Netto = 2000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 9, Netto = 12000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 9, Netto = 2030, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 10, Netto = 2000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 10, Netto = 2000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 1, Netto = 21000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 2, Netto = 2020, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 11, Netto = 2000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 12, Netto = 2000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2000, Month = 4, Netto = 12000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2000, Month = 5, Netto = 2000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2000, Month = 6, Netto = 2000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 6, Netto = 1000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 7, Netto = 6000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2002, Month = 8, Netto = 2500, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2000, Month = 9, Netto = 2000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 9, Netto = 12040, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 10, Netto = 2001, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 11, Netto = 12000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 12, Netto = 1000, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2001, Month = 12, Netto = 1111, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2002, Month = 12, Netto = 1222, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2003, Month = 12, Netto = 1333, UserId = newUserId });
                outcomes.Add(new Outcome { Id = Guid.NewGuid(), Year = 2004, Month = 12, Netto = 1444, UserId = newUserId });

                this.database.SetOutcomes(outcomes);
            }

            return true;
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