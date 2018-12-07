namespace SeleniumWebDriver.Utils
{
    using SeleniumWebDriver.Driver;

    public class DriverHelper
    {
        public static void GoToUrl(string url)
        {
            DriverSingletone.GetDriver().Navigate().GoToUrl(url);
        }
    }
}
