namespace SolidSavings.Web.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SolidSavings.Web.Models;

    public class EFDatabase : ISolidDatabase
    {
        private readonly SqlContext context;

        public EFDatabase(SqlContext context)
        {
            this.context = context;
        }

        public List<Outcome> GetOutcomes(Guid currentUserId)
        {
            return this.context.Outcomes.Where(o => o.UserId == currentUserId).ToList();
        }

        public List<Income> GetIncomes(Guid currentUserId)
        {
            return this.context.Incomes.Where(i => i.UserId == currentUserId).ToList();
        }

        public void AddIncome(Income income)
        {
            this.context.Incomes.Add(income);
            this.context.SaveChanges();
        }

        public void AddOutcome(Outcome outcome)
        {
            this.context.Outcomes.Add(outcome);
            this.context.SaveChanges();
        }

        public void SetIncomes(List<Income> incomes)
        {
            var userId = incomes.First().UserId;
            var incomesToRemove = this.context.Incomes.Where(i => i.UserId == userId).ToList();
            this.context.Incomes.RemoveRange(incomesToRemove);
            this.context.Incomes.AddRange(incomes);
            this.context.SaveChanges();
        }

        public void SetOutcomes(List<Outcome> outcomes)
        {
            var userId = outcomes.First().UserId;
            var outcomesToRemove = this.context.Outcomes.Where(i => i.UserId == userId).ToList();
            this.context.Outcomes.RemoveRange(outcomesToRemove);
            this.context.Outcomes.AddRange(outcomes);
            this.context.SaveChanges();
        }

        public void RemoveIncome(Guid id)
        {
            var income = this.context.Incomes.Single(i => i.Id == id);
            this.context.Incomes.Remove(income);
            this.context.SaveChanges();
        }

        public void RemoveOutcome(Guid id)
        {
            var outcome = this.context.Outcomes.Single(i => i.Id == id);
            this.context.Outcomes.Remove(outcome);
            this.context.SaveChanges();
        }

        public List<SolidUser> GetUsers()
        {
            return this.context.Users.ToList();
        }

        public void AddUser(SolidUser solidUser)
        {
            this.context.Users.Add(solidUser);
            this.context.SaveChanges();
        }
    }
}