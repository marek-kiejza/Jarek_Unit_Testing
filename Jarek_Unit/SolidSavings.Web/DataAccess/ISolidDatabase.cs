namespace SolidSavings.Web.DataAccess
{
    using System;
    using System.Collections.Generic;

    using SolidSavings.Web.Models;

    public interface ISolidDatabase
    {
        List<Outcome> GetOutcomes(Guid currentUserId);

        List<Income> GetIncomes(Guid currentUserId);

        void AddIncome(Income income);

        void AddOutcome(Outcome outcome);

        void SetIncomes(List<Income> incomes);

        void SetOutcomes(List<Outcome> outcomes);

        void RemoveIncome(Guid id);

        void RemoveOutcome(Guid id);

        List<SolidUser> GetUsers();

        void AddUser(SolidUser solidUser);
    }
}