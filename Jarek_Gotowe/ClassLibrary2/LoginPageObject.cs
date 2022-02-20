using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ClassLibrary2
{
    public class LoginPageObject
    {
        public LoginPageObject(IWebDriver driver)
        {
            PageFactory.InitElements(this, new DefaultElementLocator(driver));
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div[2]/div[3]/div/form/div[2]/div/div/button")]
        public IWebElement LoginButton { get; set; }

        [FindsBy(How = How.Id, Using = "Username")]
        public IWebElement LoginTextInput { get; set; }

        public void LoginAs(string qwe)
        {
            this.LoginTextInput.SendKeys(qwe);
            this.LoginButton.Click();
        }
    }
}