namespace SeleniumWebDriver.Utils
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public static class Asserts
    {
        public static void AreEquals(this string actualEmail, string expectedEmail)
        {
            Assert.AreEqual(actualEmail, expectedEmail, $"Strings are not the same." +
                $"\nExpected: '{expectedEmail}'" +
                $"\nActual: '{actualEmail}' ");
        }
    }
}
