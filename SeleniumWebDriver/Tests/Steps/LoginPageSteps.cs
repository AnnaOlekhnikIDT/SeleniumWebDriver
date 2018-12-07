namespace SeleniumWebDriver.Tests
{
    using SeleniumWebDriver.Data;
    using SeleniumWebDriver.Entity;
    using SeleniumWebDriver.UI;
    using SeleniumWebDriver.Utils;
    using System;
    using TechTalk.SpecFlow;

    [Binding]
    public class LoginPageSteps
    {
        private ILoginable user;
        private string expectedEmail;

        #region Action Steps
        [StepDefinition(@"Open Gmail main page")]
        public void OpenGmailMainPage()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.OpenPage();
        }

        [StepDefinition(@"Authorize as ""(.*)"" user")]
        public void AuthorizeAsUser(string typeOfUser)
        {          
            switch (typeOfUser)
            {
                case "default":
                    {
                        user = new UserEntity().GetDefaultUserInfo();
                        expectedEmail = user.Email;
                        break;
                    }

                case "new":
                    {
                        user = new UserEntity().GetNewUserInfo();
                        expectedEmail = user.Email;
                       break;
                    }

                default:
                    throw new Exception($"Incorrect type o user: '{typeOfUser}'");
            }
            LoginPage loginPage = new LoginPage();
            loginPage.SetUserData(user);
        }

        [StepDefinition(@"Authorize with ""(.*)"" email and ""(.*)"" password")]
        public void AuthorizeWithCreds(string email, string pass)
        {
            user = new UserEntity();
            user.Email = email;
            user.Password = pass;

            expectedEmail = email;
            LoginPage loginPage = new LoginPage();
            loginPage.SetUserData(user);
        }
        #endregion

        #region Asserts Steps
        [StepDefinition(@"Verify user authorized successfully")]
        public void VerifyUserAuthorizedSuccessfully()
        {
            MailPage mailPage = new MailPage();
            string actualEmail = mailPage.CheckUserAuthorized().GetAttribute("innerText");
            Asserts.AreEquals(actualEmail, expectedEmail); //
        }
        #endregion
    }
}