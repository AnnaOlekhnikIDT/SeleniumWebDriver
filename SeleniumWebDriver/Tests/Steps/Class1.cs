namespace SeleniumWebDriver.Tests
{
    using SeleniumWebDriver.Data;
    using SeleniumWebDriver.Entity;
    using SeleniumWebDriver.UI;
    using SeleniumWebDriver.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public class LoginPageSteps
    {
        private ILoginable user;

        #region Action Steps
        [StepDefinition(@"Open Gmail main page")]
        public void OpenGmailMainPage(ILoginable user)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.OpenPage();
        }

        [StepDefinition(@"Authorize user")]
        public MailPage AuthorizeUser()
        {
            user = new UserEntity().GetDefaultUserInfo();
            LoginPage loginPage = new LoginPage();
            return loginPage.SetUserData(user);
        }
        #endregion

        #region Asserts Steps
        [StepDefinition(@"Verify user authorized successfully")]
        public void VerifyUserAuthorizedSuccessfully()
        {
            MailPage mailPage = new MailPage();
            string actualEmail = mailPage.CheckUserAuthorized().GetAttribute("innerText");
            Asserts.AreEquals(actualEmail, user.Email);
        }
        #endregion
    }
}