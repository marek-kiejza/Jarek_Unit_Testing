using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SolidSavings.Web.DataAccess;
using SolidSavings.Web.Logic;
using SolidSavings.Web.Models;

namespace ClassLibrary1.UserBusinessTests
{
    public class Create45IncomesForUserTests
    {

        [Test]
        public void Creates45IncomesForUser()
        {
            // arrange
            var mocker = new AutoMoq.AutoMoqer();

            var cut = mocker.Create<UserBusiness>();
            var mockDatabase = mocker.GetMock<ISolidDatabase>();

            mockDatabase.Setup(s => s.GetUsers()).Returns(new List<SolidUser>());

            // act
            cut.Create45IncomesForUser(Guid.Empty);

            // assert
            mockDatabase.Verify(v => v.SetIncomes(It.Is<List<Income>>(p => p.Count == 45)));
        }
    }
}