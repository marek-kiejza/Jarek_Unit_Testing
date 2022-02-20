using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ClassLibrary2
{
    public class AddIncomePageObject
    {
        private readonly IWebDriver driver;

        public AddIncomePageObject(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new DefaultElementLocator(driver));
        }

        [FindsBy(How = How.Id, Using = "IncomeNetto")]
        public IWebElement NettoInputText { get; set; }

        [FindsBy(How = How.Id, Using = "Year")]
        public IWebElement YearInputText { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[2]/div[3]/div/form/button")]
        public IWebElement IncomeButtonAccept { get; set; }

        public void AddIncome(int netto, int year)
        {
            this.NettoInputText.SendKeys(netto.ToString());
            this.YearInputText.SendKeys(year.ToString());
            this.IncomeButtonAccept.Click();
        }
    }
}