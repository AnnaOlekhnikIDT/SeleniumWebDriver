using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWebDriver.Data;
using SeleniumWebDriver.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriver.Utils
{
    public static class ElementWaitHelper
    {
        public static void WaitForElementIsDisplayed(this IWebElement element, int timeout = WaitTime.MiddleWait)
        {
            InitWaitHelper.GetWebDriverWait(timeout).Until((driver) => element.Displayed);
        }

        public static void WaitForElementToBeClickable(this IWebElement element, int timeout = WaitTime.MiddleWait)
        {
            InitWaitHelper.GetWebDriverWait(timeout).Until(ExpectedConditions.ElementToBeClickable(element));

        }

        public static void WaitForTextIsPresent(this IWebElement element, string text, int timeout = WaitTime.MiddleWait)
        {
            InitWaitHelper.GetWebDriverWait(timeout).Until(ExpectedConditions.TextToBePresentInElement(element, text));
        }
    }
}
