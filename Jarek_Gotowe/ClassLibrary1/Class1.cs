using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SolidSavings.Web.DataAccess;
using SolidSavings.Web.Logic;
using SolidSavings.Web.Models;

namespace ClassLibrary1
{
    public class Class1
    {
        [Test]
        public void f()
        {
            var test = new Business(new InMemoryDatabase());
            test.AddIncomeToCurrentUser(new Income());
        }

        [Test]
        public void g()
        {
            var test = new Business(new TestDatabase());
            test.AddIncomeToCurrentUser(new Income());
        }

        [Test]
        public void h()
        {
            var solidDatabase = new TestDatabase();
            var test = new Business(solidDatabase);
            test.AddIncomeToCurrentUser(new Income());

            if (!solidDatabase.AddIncomeWasRun)
            {
                throw new Exception("Add IncomeWas not Run");
            }
        }

        [Test]
        public void i()
        {
            var solidDatabase = new TestDatabase();
            var test = new Business(solidDatabase);

            test.AddIncomeToCurrentUser(new Income());

            if (!solidDatabase.AddIncomeWasRun)
            {
                throw new Exception("Add IncomeWas not Run");
            }

            if (solidDatabase.GetOutcomesWasRun ||
                solidDatabase.GetIncomesWasRun ||
                solidDatabase.AddOutcomeWasRun)
            {
                throw new Exception("other were");
            }
        }

        [Test]
        public void j()
        {
            var database = new Mock<ISolidDatabase>();

            var test = new Business(database.Object);

            test.AddIncomeToCurrentUser(new Income());

            database.Verify(v => v.AddIncome(It.IsAny<Income>()), Times.Once);
            database.Verify(v => v.AddOutcome(It.IsAny<Outcome>()), Times.Never);
        }


        [Test]
        public void this_is_just_a_test_of_a_test()
        {
            var database = new Mock<ISolidDatabase>();

            var test = new Business(database.Object);

            var c = test.this_is_just_a_test(new List<int>());

            Assert.AreEqual(0, c);
        }

        [Test]
        public void k()
        {
            var database = new Mock<ISolidDatabase>();

            var test = new Business(database.Object);

            var income = new Income
            {
                Netto = 100
            };

            test.AddIncomeToCurrentUser(income);

            database.Verify(v => v.AddIncome(It.Is<Income>(p => p.Netto == 100)), Times.Once);
        }

        [Test]
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(100000)]
        public void l(decimal n)
        {
            var database = new Mock<ISolidDatabase>();

            var test = new Business(database.Object);

            var income = new Income
            {
                Netto = n
            };

            test.AddIncomeToCurrentUser(income);

            database.Verify(v => v.AddIncome(It.Is<Income>(p => p.Netto == n)), Times.Once);
        }

        [TestCaseSource("numbers")]
        public void l2(decimal n)
        {
            var database = new Mock<ISolidDatabase>();

            var test = new Business(database.Object);

            var income = new Income
            {
                Netto = n
            };

            test.AddIncomeToCurrentUser(income);

            database.Verify(v => v.AddIncome(It.Is<Income>(p => p.Netto == n)), Times.Once);
        }
        static decimal[] numbers = new decimal[] { 0m, 10, 100, 100000 };

        [TestCaseSource("incomes")]
        public void l3(Income n)
        {
            var database = new Mock<ISolidDatabase>();

            var test = new Business(database.Object);

            test.AddIncomeToCurrentUser(n);

            database.Verify(v => v.AddIncome(It.Is<Income>(p => p.Netto == n.Netto)), Times.Once);
        }
        static Income[] incomes = new Income[] { new Income { Netto = 0 }, new Income { Netto = 100 } };
    }

    public class TestDatabase : ISolidDatabase
    {
        public bool AddIncomeWasRun { get; set; }
        public bool GetOutcomesWasRun { get; set; }
        public bool GetIncomesWasRun { get; set; }
        public bool AddOutcomeWasRun { get; set; }

        public List<Outcome> GetOutcomes(Guid currentUserId)
        {
            this.GetOutcomesWasRun = true;
            return null;
        }

        public List<Income> GetIncomes(Guid currentUserId)
        {
            this.GetIncomesWasRun = true;
            return null;
        }

        public void AddIncome(Income income)
        {
            this.AddIncomeWasRun = true;
        }

        public void AddOutcome(Outcome outcome)
        {
            this.AddOutcomeWasRun = true;
        }

        public void SetIncomes(List<Income> incomes)
        {
            throw new NotImplementedException();
        }

        public void SetOutcomes(List<Outcome> outcomes)
        {
            throw new NotImplementedException();
        }

        public void RemoveIncome(Guid id)
        {
            throw new NotImplementedException();
        }

        public void RemoveOutcome(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<SolidUser> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void AddUser(SolidUser solidUser)
        {
            throw new NotImplementedException();
        }

    }
}
