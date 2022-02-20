namespace SolidSavings.Web.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ClosedXML.Excel;

    using SolidSavings.Web.Models;

    public class InMemoryDatabase : ISolidDatabase
    {
        public InMemoryDatabase()
        {
            this.Outcomes = new List<Outcome>();
            this.Incomes = new List<Income>();
            this.Users = new List<SolidUser>();
        }

        private List<Outcome> Outcomes { get; }
        private List<Income> Incomes { get; }
        private List<SolidUser> Users { get; }

        public List<Outcome> GetOutcomes(Guid currentUserId)
        {
            return this.Outcomes.Where(o => o.UserId == currentUserId).ToList();
        }

        public List<Income> GetIncomes(Guid currentUserId)
        {
            return this.Incomes.Where(o => o.UserId == currentUserId).ToList();
        }

        public void AddIncome(Income income)
        {
            this.Incomes.Add(income);
        }

        public void AddOutcome(Outcome outcome)
        {
            this.Outcomes.Add(outcome);
        }

        public void SetIncomes(List<Income> incomes)
        {
            var userId = incomes.First().UserId;
            var toRemove = this.Incomes.Where(i => i.UserId == userId);
            toRemove.ForEach(i => this.Incomes.Remove(i));
            this.Incomes.AddRange(incomes);
        }

        public void SetOutcomes(List<Outcome> outcomes)
        {
            var userId = outcomes.First().UserId;
            var toRemove = this.Outcomes.Where(i => i.UserId == userId);
            toRemove.ForEach(i => this.Outcomes.Remove(i));
            this.Outcomes.AddRange(outcomes);
        }

        public void RemoveIncome(Guid id)
        {
            var income = this.Incomes.Single(i => i.Id == id);
            this.Incomes.Remove(income);
        }

        public void RemoveOutcome(Guid id)
        {
            var outcome = this.Outcomes.Single(i => i.Id == id);
            this.Outcomes.Remove(outcome);
        }

        public List<SolidUser> GetUsers()
        {
            return this.Users;
        }

        public void AddUser(SolidUser solidUser)
        {
            this.Users.Add(solidUser);
        }
    }
}