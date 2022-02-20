using System;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ClassLibrary2
{
    [TestFixture]
    public class TestClassIncome
    {
        public IWebDriver Driver { get; set; }

        [Test]
        public void fghij()
        {
            var options = new ChromeOptions();

            var httpsWwwGoogleCom = "http://localhost:50614/";

            Driver = new ChromeDriver(options);

            Driver.Navigate().GoToUrl(httpsWwwGoogleCom);

            // login page
            var loginButton = Driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[3]/div/form/div[2]/div/div/button"));
            var loginText = Driver.FindElement(By.Id("Username"));

            loginText.SendKeys("qwe");
            loginButton.Click();

            // home page
            var listIncomesButton = Driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[2]/a[2]"));
            listIncomesButton.Click();

            // incomes page
            var originalIncomesCount = Driver.FindElements(By.TagName("tr")).Count;

            var incomesButton = Driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/a[1]"));
            incomesButton.Click();

            // home page
            var addIncomeButton = Driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[2]/a[1]"));
            addIncomeButton.Click();

            // add income page
            var incomeInput = Driver.FindElement(By.Id("IncomeNetto"));
            incomeInput.SendKeys("1000");

            var yearInput = Driver.FindElement(By.Id("Year"));
            yearInput.SendKeys("2000");

            var acceptIncomeButton = Driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[3]/div/form/button"));
            acceptIncomeButton.Click();

            // home
            listIncomesButton = Driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[2]/a[2]"));
            listIncomesButton.Click();

            // incomes page
            var newIncomesCount = Driver.FindElements(By.TagName("tr")).Count;


            Assert.True(newIncomesCount > originalIncomesCount);
        }

        [Test]
        public void fghij2()
        {
            var x = Assembly.GetExecutingAssembly().Location;
            var path = new FileInfo(x);
            var directory = path.Directory;

            var options = new ChromeOptions();

            var httpsWwwGoogleCom = "http://localhost:50614/";

            Driver = new ChromeDriver(options);

            Driver.Navigate().GoToUrl(httpsWwwGoogleCom);

            var loginPage = new LoginPageObject(Driver);
            ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile($"{directory}/1.png");
            loginPage.LoginAs("qwe");

            var homePage = new HomePageObject(Driver);
            ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile($"{directory}/2.png");
            homePage.NavigateToIncomes();

            var incomesPage = new IncomesPageObject(Driver);
            ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile($"{directory}/3.png");

            var originalIncomesCount = incomesPage.GetCountOfIncomes();
            incomesPage.NavigateToHomePage();

            homePage = new HomePageObject(Driver);
            ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile($"{directory}/4.png");
            homePage.NavigateToAddIncomePage();

            var addIncomePage = new AddIncomePageObject(Driver);
            ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile($"{directory}/5.png");
            addIncomePage.AddIncome(1000, 2000);

            homePage = new HomePageObject(Driver);
            ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile($"{directory}/6.png");
            homePage.NavigateToIncomes();

            incomesPage = new IncomesPageObject(Driver);
            ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile($"{directory}/7.png");
            var newIncomesCount = incomesPage.GetCountOfIncomes();

            Assert.True(newIncomesCount > originalIncomesCount);
        }

        [TearDown]
        public void sldflksdjflkasjdlfkjas()
        {
            Driver.Quit();
            Driver.Dispose();
            Driver = null;
        }
    }
}