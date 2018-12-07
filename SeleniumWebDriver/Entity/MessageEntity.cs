using SeleniumWebDriver.Utils;

namespace SeleniumWebDriver.Data
{
    public class MessageEntity
    {
        public string Theme
        { set; get; }

        public string Text
        { set; get; }

        public string Reciever
        { set; get; }

        public static MessageEntity GetDefaultMessageInfo()
        {
            MessageEntity message = new MessageEntity
            {
                Reciever = ResourceManagerUtils.GetCurrentEnvironmentData("email"),
                Text = ResourceManagerUtils.GetCurrentEnvironmentData("message_text"),
                Theme = ResourceManagerUtils.GetCurrentEnvironmentData("message_theme")
            };

            return message;
        }

    }
}
