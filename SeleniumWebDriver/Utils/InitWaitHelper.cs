using OpenQA.Selenium.Support.UI;
using SeleniumWebDriver.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriver.Utils
{
    public class InitWaitHelper
    {
        private static int defaultTimeout = 10;

        public static WebDriverWait GetWebDriverWait()
        {
            return GetWebDriverWait(defaultTimeout);
        }

        public static WebDriverWait GetWebDriverWait(int timeout)
        {
            return new WebDriverWait(DriverSingletone.GetDriver(), TimeSpan.FromSeconds(timeout));
        }
    }
}
