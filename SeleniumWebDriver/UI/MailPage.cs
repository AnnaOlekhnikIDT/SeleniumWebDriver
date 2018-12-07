namespace SeleniumWebDriver.UI
 {
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using SeleniumWebDriver.Data;
    using SeleniumWebDriver.Driver;
    using SeleniumWebDriver.Utils;
    using System;
    using System.Threading;

    public class MailPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='gb']/div[2]/div[3]/div/div[2]/div/a/span")]
        private IWebElement account;

        [FindsBy(How = How.XPath, Using = "//*[@id='gb']/div[2]/div[6]/div[1]/div/div[2]")]
        private IWebElement authorizedEmail;

        [FindsBy(How = How.XPath, Using = "//*[@class='T-I J-J5-Ji T-I-KE L3']")]
        private IWebElement writeButton;

        [FindsBy(How = How.XPath, Using = "//textarea[@name='to']")]
        private IWebElement recieverField;

        [FindsBy(How = How.XPath, Using = "//input[@name='subjectbox']")]
        private IWebElement themeField;

        [FindsBy(How = How.XPath, Using = "//*[@class='Am Al editable LW-avf']")]
        private IWebElement messageField;

        [FindsBy(How = How.XPath, Using = "//*[contains(@class,'aoO')]")]
        private IWebElement sendButton;

        [FindsBy(How = How.XPath, Using = "//*[@class='bAq']")]
        private IWebElement infoTable;

        [FindsBy(How = How.XPath, Using = "//*[@class='oZ-x3 xY']")]
        private IWebElement firstIncomingLetter;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'nX')]/div")]
        private IWebElement deleteButton;

        public MailPage()
        {
            PageFactory.InitElements(DriverSingletone.GetDriver(), this);
        }

        public override void OpenPage()
        {
            throw new NotSupportedException("Only for authorized users");
        }

        public IWebElement CheckUserAuthorized()
        {
            account.ClickAfterWaiting();
            return authorizedEmail;
        }

        public void CreateNewLetter()
        {
            writeButton.ClickAfterWaiting();
        }

        public void FillingDefaultEmailForm(MessageEntity message)
        {
            recieverField.FillInFieldAndSubmit(message.Reciever);
            recieverField.SubmitFilling();
            themeField.FillInFieldAndSubmit(message.Theme);
            messageField.FillInField(message.Text);
        }

        public void FillInRecieverField(string text) {

            recieverField.FillInFieldAndSubmit(text);
            recieverField.SubmitFilling();

        }

        public void FillInThemeField (string text) {

            themeField.FillInFieldAndSubmit(text);
        }

        public void FillInBodyOfMessage(string text) {

            messageField.FillInField(text);
        }

        public void SubmitSending()
        {
            sendButton.Click();
        }

        public IWebElement CheckEmailSendingInfo(string text)
        {
            new MailPage();
            infoTable.WaitForTextIsPresent(text);
            return infoTable;
        }

        public void DeleteLetter()
        {
            //deleteButton.Click();
            deleteButton.ClickAfterWaiting();
        }

        public void TickLetter()
        {
            firstIncomingLetter.ClickAfterWaiting();
        }

        public IWebElement CheckEmailRemoveInfo(string text)
        {
            infoTable.WaitForTextIsPresent(text);
            return infoTable;
        }
    }
}
