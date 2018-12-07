namespace SeleniumWebDriver.Utils
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SeleniumWebDriver.Driver;
    using System;
    
    

    public static class ElementActionHelper
    {
        public static void ClickAfterWaiting(this IWebElement element, bool retry = true)
        {
            try
            {
                element.WaitForElementIsDisplayed();           
                element.Click();
            }
            catch (Exception e)
            {
                if (retry == true) { ClickAfterWaiting(element, false); }
                else { throw e; }
            }
        }

        public static void FillInFieldAndSubmit(this IWebElement element, string key)
        {
            element.Clear();
            element.SendKeys(key);
            element.Click();
        }

        public static void FillInField(this IWebElement element, string key)
        {
            element.Clear();
            element.SendKeys(key);
        }

        public static void SubmitFilling(this IWebElement element)
        {
            element.SendKeys(Keys.Enter);
        }

        public static void ClickWhitJSHelp(this IWebElement element)
        {
            new WebDriverWait(DriverSingletone.GetDriver(), TimeSpan.FromSeconds(5)).Until(
          d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            ((IJavaScriptExecutor)DriverSingletone.GetDriver()).ExecuteScript("arguments[0].click()", element);
        }
}
}
