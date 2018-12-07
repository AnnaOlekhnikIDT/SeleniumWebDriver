namespace SeleniumWebDriver.UI
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using SeleniumWebDriver.Driver;
    using SeleniumWebDriver.Entity;
    using SeleniumWebDriver.Utils;

    public class LoginPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='identifierId']")]
        private IWebElement mailAddressField;

        [FindsBy(How = How.XPath, Using = "//span[@class='RveJvd snByac']")]
        private IWebElement nextButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='password']//input[@name='password']")]
        private IWebElement passwordField;

        public LoginPage()
        {
            PageFactory.InitElements(DriverSingletone.GetDriver(), this);
        }

        public override void OpenPage()
        {
            DriverHelper.GoToUrl(ResourceManagerUtils.GetCurrentEnvironmentData("url"));
        }

        public MailPage SetUserData(ILoginable user)
        {
            mailAddressField.FillInField(user.Email);
            nextButton.WaitForElementToBeClickable();
            nextButton.Click();
            passwordField.WaitForElementToBeClickable();
            passwordField.FillInField(user.Password);
            ClickNextButton();
            return new MailPage();
        }

        public void ClickNextButton()
        {
            IWebElement element = DriverSingletone.GetDriver().FindElement(By.XPath("//span[@class='RveJvd snByac']"));
            //element.WaitForElementToBeClickable();
            element.WaitForElementIsDisplayed();
            element.Click();
        }

    }
}
