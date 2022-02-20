using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ClassLibrary2
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void f()
        {
            IWebDriver Driver;
            var options = new ChromeOptions();

            var httpsWwwGoogleCom = "https://selenium-python.readthedocs.io/getting-started.html";

            Driver = new ChromeDriver(options);

            Driver.Navigate().GoToUrl(httpsWwwGoogleCom);

            System.Diagnostics.Trace.WriteLine(Driver.Title);

            Driver.Quit();
            Driver.Dispose();
            Driver = null;
            Assert.Pass();
        }

        [Test]
        public void fg()
        {
            IWebDriver Driver;
            var options = new ChromeOptions();

            var httpsWwwGoogleCom = "http://localhost:50614/";

            Driver = new ChromeDriver(options);

            Driver.Navigate().GoToUrl(httpsWwwGoogleCom);

            System.Diagnostics.Trace.WriteLine(Driver.Title);

            Driver.Quit();
            Driver.Dispose();
            Driver = null;
            Assert.Pass();
        }

        [Test]
        public void fgh()
        {
            IWebDriver Driver;
            var options = new ChromeOptions();

            var httpsWwwGoogleCom = "http://localhost:50614/";

            Driver = new ChromeDriver(options);

            Driver.Navigate().GoToUrl(httpsWwwGoogleCom);

            var findElement = Driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[3]/div/form/div[2]/div/div/button"));

            Assert.True(findElement.Displayed);

            Driver.Quit();
            Driver.Dispose();
            Driver = null;
        }

        [Test]
        public void fghi()
        {
            IWebDriver Driver;
            var options = new ChromeOptions();

            var httpsWwwGoogleCom = "http://localhost:50614/";

            Driver = new ChromeDriver(options);

            Driver.Navigate().GoToUrl(httpsWwwGoogleCom);

            var loginButton = Driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[3]/div/form/div[2]/div/div/button"));

            loginButton.Click();

            Assert.True(Driver.Title == "Solid Savings");

            Driver.Quit();
            Driver.Dispose();
            Driver = null;
        }

        [Test]
        public void fghij()
        {
            IWebDriver Driver;
            var options = new ChromeOptions();

            var httpsWwwGoogleCom = "http://localhost:50614/";

            Driver = new ChromeDriver(options);

            Driver.Navigate().GoToUrl(httpsWwwGoogleCom);

            var loginButton = Driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[3]/div/form/div[2]/div/div/button"));
            var loginText = Driver.FindElement(By.Id("Username"));

            loginText.SendKeys("demo");
            loginButton.Click();

            var logoutButton = Driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/a[6]"));

            Assert.True(logoutButton.Displayed);

            Driver.Quit();
            Driver.Dispose();
            Driver = null;
        }
    }
}
