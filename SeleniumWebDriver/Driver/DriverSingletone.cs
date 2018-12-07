namespace SeleniumWebDriver.Driver
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DriverSingletone
    {
        //private static string Chrome = "webdriver.chrome.driver"; //final

	    private static IWebDriver driver;
        private static readonly Object obj = new object();

        private DriverSingletone()
        {
        }

        public static IWebDriver GetDriver()
        {
            lock (obj)
            {
                if (null == driver)
                {
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();

                }
            }
            return driver;
        }

        public static void CloseDriver()
        {
            driver.Quit();
            driver = null;
        }
    }
}
