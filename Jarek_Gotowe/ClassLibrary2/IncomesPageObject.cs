using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ClassLibrary2
{
    public class IncomesPageObject
    {
        private readonly IWebDriver driver;

        public IncomesPageObject(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new DefaultElementLocator(driver));
        }

        public int GetCountOfIncomes()
        {
            return this.driver.FindElements(By.TagName("tr")).Count - 1;
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[1]/div[2]/div/a[1]")]
        public IWebElement IncomesButton { get; set; }

        public void NavigateToHomePage()
        {
            this.IncomesButton.Click();
        }
    }
}