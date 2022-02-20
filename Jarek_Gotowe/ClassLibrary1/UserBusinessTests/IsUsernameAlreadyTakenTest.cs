using System.Collections.Generic;
using NUnit.Framework;
using SolidSavings.Web.DataAccess;
using SolidSavings.Web.Logic;

namespace ClassLibrary1.UserBusinessTests
{
    public class IsUsernameAlreadyTakenTest
    {
        [TestCase("ok", false)]
        [TestCase("ala", true)]
        [TestCase("alą", true)]
        [TestCase("alA", true)]
        [TestCase("alĄ", true)]
        public void IsUsernameAlreadyTaken(string username, bool expected)
        {
            // arrange
            var mocker = new AutoMoq.AutoMoqer();

            var cut = mocker.Create<UserBusiness>();
            var mockDatabase = mocker.GetMock<ISolidDatabase>();

            mockDatabase.Setup(s => s.GetUsers()).Returns(new List<SolidUser>
            {
                new SolidUser
                {
                    Name = username
                }
            });

            // act
            var actual = cut.IsUsernameAlreadyTaken("ala");

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}