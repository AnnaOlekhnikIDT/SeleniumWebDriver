namespace SeleniumWebDriver
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using SeleniumWebDriver.Driver;
    using SeleniumWebDriver.Tests;
    using TechTalk.SpecFlow;

    [Binding]
    public class BaseTest
    {
        protected IWebDriver driver;
        //protected LoginPageSteps steps;

        [BeforeScenario]
        public void SetUpDriver()
        {
            driver = DriverSingletone.GetDriver();           
        }

        [AfterScenario]
        public void CloseDriver()
        {
            DriverSingletone.CloseDriver();
        }

    }
}
