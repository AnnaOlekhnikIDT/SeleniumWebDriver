namespace SeleniumWebDriver.Tests.Steps
{
    using OpenQA.Selenium;
    using SeleniumWebDriver.Data;
    using SeleniumWebDriver.Enum;
    using SeleniumWebDriver.UI;
    using SeleniumWebDriver.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public class MailPageSteps
    {
        #region Action Steps
        [StepDefinition(@"I open send Email form")]
        public void OpenSendEmailForm()
        {
            MailPage mailPage = new MailPage();
            mailPage.CreateNewLetter();
        }

        [StepDefinition(@"I fill in ""(.*)"" field with ""(.*)""")]
        public void FillInFieldWith(FieldEnum fieldName, string text)
        {
            MailPage mailPage = new MailPage();
            if (text == "default")
            {
                MessageEntity message = MessageEntity.GetDefaultMessageInfo();
                mailPage.FillingDefaultEmailForm(message);
            }
            else
            {
                switch (fieldName)
                {
                    case FieldEnum.Reciever:
                        {
                            mailPage.FillInRecieverField(text);
                            break;
                        }
                    case FieldEnum.Theme:
                        {
                            mailPage.FillInThemeField(text);
                            break;
                        }
                    case FieldEnum.Body:
                        {
                            mailPage.FillInBodyOfMessage(text);
                            break;
                        }
                    default:
                        { throw new NoSuchElementException
                                ($"Field with '{fieldName}' name is not found");
                        }
                }
            }
        }

        [StepDefinition(@"I submit email sending")]
        public void SubmitEmailSending()
        {
            MailPage mailPage = new MailPage();
            mailPage.SubmitSending();
        }

        [StepDefinition(@"Remove email message")]
        public void RemoveEmailMessage()
        {
            MailPage mailPage = new MailPage();
            mailPage.TickLetter();
            mailPage.DeleteLetter();
        }
        #endregion

        #region Asserts Steps
        [StepDefinition(@"Verify email was successfully sent")]
        public void VerifyEmailWasSuccessfullySent()
        {
            MailPage mailPage = new MailPage();
            string actualInfo = mailPage.CheckEmailSendingInfo("Message sent.")
                .GetAttribute("innerText");
            Asserts.AreEquals(actualInfo, "Message sent.");
        }

        [StepDefinition(@"Verify email message was removed")]
        public void VerifyEmailMessageWasRemoved()
        {
            string expectedInfo = "Conversation moved to Trash.";
            MailPage mailPage = new MailPage();
            string actualInfo = mailPage.CheckEmailRemoveInfo(expectedInfo)
                .GetAttribute("innerText");
            Asserts.AreEquals(actualInfo, expectedInfo);
        }
        #endregion
    }
}
