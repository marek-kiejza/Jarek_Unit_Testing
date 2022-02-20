using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ClassLibrary2
{
    public class HomePageObject
    {
        public HomePageObject(IWebDriver driver)
        {
            PageFactory.InitElements(this, new DefaultElementLocator(driver));
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[2]/div[1]/div[2]/a[2]")]
        public IWebElement IncomesMenuLink { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[2]/div[1]/div[2]/a[1]")]
        public IWebElement AddIncomesButton { get; set; }

        public void NavigateToIncomes()
        {
            this.IncomesMenuLink.Click();
        }

        public void NavigateToAddIncomePage()
        {
            this.AddIncomesButton.Click();
        }
    }
}