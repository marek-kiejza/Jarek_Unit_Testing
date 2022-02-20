using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.QualityTools.Testing.Fakes;
using Moq;
using NUnit.Framework;
using SolidSavings.Web.Controllers;
using SolidSavings.Web.DataAccess;
using SolidSavings.Web.Infrastructure;
using SolidSavings.Web.Logic;
using SolidSavings.Web.Models;

namespace ClassLibrary1
{
    class Class3
    {
        [Test]
        public void f()
        {
            // arrange
            var inMemoryDatabase = new InMemoryDatabase();

            var business = new Business(inMemoryDatabase);
            var userBusiness = new UserBusiness(inMemoryDatabase);
            var solidExporter = new SolidExporter(new[] { new SolidExporterJson(business) });

            var home = new HomeController(business, userBusiness, solidExporter);

            // act
            home.AddIncome(new AddIncomeDto());

            // assert
            Assert.AreEqual(1, inMemoryDatabase.GetIncomes(Guid.Empty).Count);
        }

        [Test]
        public void g()
        {
            var connectionString = "Server=.;Database=save;Trusted_Connection=True;MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<SqlContext>();
            var x = optionsBuilder.UseSqlServer(connectionString, providerOptions => providerOptions.CommandTimeout(60));
            var sqlContext = new SqlContext(x.Options);
            var db = new EFDatabase(sqlContext);
            var business = new Business(db);
            var json = new SolidExporterJson(business);

            var currentUserId = Guid.NewGuid();
            SolidSession.CurrentUserId = currentUserId;

            var prev = sqlContext.Incomes.Count();

            var home = new HomeController(
                business,
                new UserBusiness(db),
                new SolidExporter(new[] { json }));

            home.AddIncome(new AddIncomeDto());
            Assert.AreEqual(sqlContext.Incomes.Count(), prev + 1);
        }

        [Test]
        public void h_in_memory()
        {
            var options = new DbContextOptionsBuilder<SqlContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            var sqlContext = new SqlContext(options);
            var db = new EFDatabase(sqlContext);
            var business = new Business(db);
            var json = new SolidExporterJson(business);

            var currentUserId = Guid.NewGuid();
            SolidSession.CurrentUserId = currentUserId;

            var home = new HomeController(
                business,
                new UserBusiness(db),
                new SolidExporter(new[] { json }));

            home.AddIncome(new AddIncomeDto());
            Assert.AreEqual(sqlContext.Incomes.Count(), 1);
        }

        [Test]
        public void lasjlksjdfk()
        {
            var mocker = new AutoMoq.AutoMoqer();

            var db = mocker.GetMock<ISolidDatabase>();

            db.Setup(s => s.GetUsers()).Returns(new List<SolidUser>());

            var ub = mocker.Create<UserBusiness>();

            using (var sc = ShimsContext.Create())
            {
                System.Fakes.ShimGuid.NewGuid = () => Guid.Empty;

                ub.RegisterNewUser("fghjk", SolidSavings.Web.Models.Enums.UserRegistrationType.Demo);

                db.Verify(v => v.AddUser(It.Is<SolidUser>(p => p.ID == Guid.Empty)));
            }
        }
    }
}
