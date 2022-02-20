using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SolidSavings.Web.DataAccess;
using SolidSavings.Web.Logic;
using SolidSavings.Web.Models;

namespace ClassLibrary1.UserBusinessTests
{
    public class Create5OutcomesForUserTest
    {

        [Test]
        public void Creates5OutcomesForUser()
        {
            // arrange
            var mocker = new AutoMoq.AutoMoqer();

            var cut = mocker.Create<UserBusiness>();
            var mockDatabase = mocker.GetMock<ISolidDatabase>();

            mockDatabase.Setup(s => s.GetUsers()).Returns(new List<SolidUser>());

            // act
            cut.Create5OutcomesForUser(Guid.Empty);

            // assert
            mockDatabase.Verify(v => v.SetOutcomes(It.Is<List<Outcome>>(p => p.Count == 5)));
        }
    }
}