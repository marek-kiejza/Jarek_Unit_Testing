using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SolidSavings.Web.DataAccess;
using SolidSavings.Web.Logic;
using SolidSavings.Web.Models;
using SolidSavings.Web.Models.Enums;

namespace ClassLibrary1.UserBusinessTests
{
    [TestFixture]
    public class RegisterDemoNewUserTests
    {
        [Test]
        public void Given_DemoUser_When_RegisterNewUser_Then_CallDatabaseOnce()
        {
            // arrange
            var mocker = new AutoMoq.AutoMoqer();

            var cut = mocker.Create<UserBusiness>(); // System Under Test - Class Under Test
            var mockDatabase = mocker.GetMock<ISolidDatabase>();

            mockDatabase.Setup(
                    s =>
                        s.GetUsers())
                .Returns(new List<SolidUser>());

            // act
            cut.RegisterNewUser("akjasdas", UserRegistrationType.Demo);

            // assert
            mockDatabase.Verify(v => v.GetUsers(), Times.Once);
        }

        [Test]
        public void Given_DemoUserNameIsAlreadyTaken_When_RegisterNewUser_Then_Returns_False()
        {
            // arrange
            var mocker = new AutoMoq.AutoMoqer();

            var cut = mocker.Create<UserBusiness>();
            var mockDatabase = mocker.GetMock<ISolidDatabase>();

            mockDatabase.Setup(
                    s =>
                        s.GetUsers())
                .Returns(new List<SolidUser>
                {
                    new SolidUser
                    {
                        Name = "testUser"
                    }
                });

            // act
            var actual = cut.RegisterNewUser("testUser", UserRegistrationType.Demo);

            // assert
            mockDatabase.Verify(v => v.GetUsers(), Times.Once);
            Assert.AreEqual(false, actual, "return value from method");
        }

        [Test]
        public void Given_DemoUser_When_RegisterNewUser_Then_Creates_45_Incomes()
        {
            // arrange
            var mocker = new AutoMoq.AutoMoqer();

            var cut = mocker.Create<UserBusiness>();
            var mockDatabase = mocker.GetMock<ISolidDatabase>();

            mockDatabase.Setup(s => s.GetUsers()).Returns(new List<SolidUser>());

            // act
            var actual = cut.RegisterNewUser("testUser", UserRegistrationType.Demo);

            // assert
            mockDatabase.Verify(v => v.GetUsers(), Times.Once);
            mockDatabase.Verify(v => v.SetIncomes(It.Is<List<Income>>(p => p.Count == 45)));
        }

        [Test]
        public void Given_DemoUser_When_RegisterNewUser_Then_Creates_5_Outcomes()
        {
            // arrange
            var mocker = new AutoMoq.AutoMoqer();

            var cut = mocker.Create<UserBusiness>();
            var mockDatabase = mocker.GetMock<ISolidDatabase>();

            mockDatabase.Setup(s => s.GetUsers()).Returns(new List<SolidUser>());

            // act
            var actual = cut.RegisterNewUser("testUser", UserRegistrationType.Demo);

            // assert
            mockDatabase.Verify(v => v.GetUsers(), Times.Once);
            mockDatabase.Verify(v => v.SetIncomes(It.Is<List<Income>>(p => p.Count == 45)));
            mockDatabase.Verify(v => v.SetOutcomes(It.Is<List<Outcome>>(p => p.Count == 5)));
        }
    }
}