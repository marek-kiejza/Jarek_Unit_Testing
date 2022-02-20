using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMoq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using SolidSavings.Web.Controllers;
using SolidSavings.Web.DataAccess;
using SolidSavings.Web.Logic;
using SolidSavings.Web.Models;

namespace ClassLibrary1
{
    public class Class2
    {
        [Test]
        public void q()
        {
            // arrange
            var moq1 = new Mock<IBusiness>();
            var moq2 = new Mock<IUserBusiness>();
            var moq3 = new Mock<ISolidExporter>();

            var home = new HomeController(moq1.Object, moq2.Object, moq3.Object);

            // act
            var result = home.AddIncome();

            // assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void w()
        {
            // arrange
            var moq1 = new Mock<IBusiness>();
            var moq2 = new Mock<IUserBusiness>();
            var moq3 = new Mock<ISolidExporter>();

            var home = new HomeController(moq1.Object, moq2.Object, moq3.Object);

            // act
            var result = home.AddIncome(new AddIncomeDto());

            // assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            Assert.IsInstanceOf<IActionResult>(result);

            moq1.Verify(v=>v.AddIncomeToCurrentUser(It.IsAny<Income>()), Times.Once);
        }

        [Test]
        public void e()
        {
            // arrange
            var moq1 = new Mock<IBusiness>();
            var moq2 = new Mock<IUserBusiness>();
            var moq3 = new Mock<ISolidExporter>();

            var home = new HomeController(moq1.Object, moq2.Object, moq3.Object);

            home.ModelState.AddModelError("alskdj", "aksjdhkajshdj");

            // act
            var result = home.AddIncome(new AddIncomeDto());

            // assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsInstanceOf<IActionResult>(result);

            moq1.Verify(v => v.AddIncomeToCurrentUser(It.IsAny<Income>()), Times.Never);
        }

        [Test]
        public void r()
        {
            // arrange
            var moq1 = new Mock<IBusiness>();
            var moq2 = new Mock<IUserBusiness>();
            var moq3 = new Mock<ISolidExporter>();

            var home = new HomeController(moq1.Object, moq2.Object, moq3.Object);

            moq2.Setup(s => s.IsDemoUser()).Returns(true);

            // act
            var result = home.AddIncome(new AddIncomeDto());

            // assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsInstanceOf<IActionResult>(result);

            moq1.Verify(v => v.AddIncomeToCurrentUser(It.IsAny<Income>()), Times.Never);
        }

        [Test]
        [TestCase(true, true, true, 0)]
        [TestCase(false, true, true, 1)]
        [TestCase(false, true, false, 0)]
        public void r(bool isDemo, bool isFree, bool canAdd, int count)
        {
            // arrange
            var moq1 = new Mock<IBusiness>();
            var moq2 = new Mock<IUserBusiness>();
            var moq3 = new Mock<ISolidExporter>();

            var home = new HomeController(moq1.Object, moq2.Object, moq3.Object);

            moq2.Setup(s => s.IsDemoUser()).Returns(isDemo);
            moq2.Setup(s => s.IsFreeUser()).Returns(isFree);
            moq1.Setup(s => s.CanAddNewIncome()).Returns(canAdd);

            // act
            var result = home.AddIncome(new AddIncomeDto());

            // assert
            Assert.IsInstanceOf<IActionResult>(result);

            moq1.Verify(v => v.AddIncomeToCurrentUser(It.IsAny<Income>()), Times.Exactly(count));
        }

        [Test]
        [TestCase(true, true, true, 0)]
        [TestCase(false, true, true, 1)]
        [TestCase(false, true, false, 0)]
        public void r2(bool isDemo, bool isFree, bool canAdd, int count)
        {
            // arrange
            var auto = new AutoMoqer();
            var home = auto.Create<HomeController>();

            var moq1 = auto.GetMock<IBusiness>();
            var moq2 = auto.GetMock<IUserBusiness>();

            moq2.Setup(s => s.IsDemoUser()).Returns(isDemo);
            moq2.Setup(s => s.IsFreeUser()).Returns(isFree);
            moq1.Setup(s => s.CanAddNewIncome()).Returns(canAdd);

            // act
            var result = home.AddIncome(new AddIncomeDto());

            // assert
            Assert.IsInstanceOf<IActionResult>(result);

            moq1.Verify(v => v.AddIncomeToCurrentUser(It.IsAny<Income>()), Times.Exactly(count));
        }

    }
}
