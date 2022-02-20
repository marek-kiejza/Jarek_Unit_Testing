namespace SolidSavings.Web.Logic
{
    using System;
    using System.Collections.Generic;

    using SolidSavings.Web.Models;

    public interface IBusiness
    {
        bool CanAddNewOutcome();

        bool CanAddNewIncome();

        void AddIncomeToCurrentUser(Income income);

        void AddOutcomeToCurrentUser(Outcome outcome);

        List<Income> GetCurrentUserCircleIncomes();

        List<Outcome> GetCurrentUserCircleOutcomes();

        List<Income> GetCurrentUserIncomes();

        List<Outcome> GetCurrentUserOutcomes();

        void SetCurrentUserIncomes(List<Income> incomes);

        void SetCurrentUserOutcomes(List<Outcome> outcomes);

        List<Income> GetCurrentUserLineIncomes();

        List<Outcome> GetCurrentUserLineOutcomes();

        List<Income> GetCurrentUserIncomesOrdered();

        List<Outcome> GetCurrentUserOutcomesOrdered();

        List<Outcome> GetCurrentUserOutcomesGrouped();

        List<Income> GetCurrentUserIncomesGrouped();

        List<Income> GetCurrentUserRadarIncomes();

        List<Outcome> GetCurrentUserRadarOutcomes();

        void RemoveIncomeFromCurrentUser(Guid id);

        void RemoveOutcomeFromCurrentUser(Guid id);

        int this_is_just_a_test(List<int> p);
    }
}