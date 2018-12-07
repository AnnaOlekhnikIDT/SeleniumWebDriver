namespace SeleniumWebDriver.Utils
{
    using System;
    using System.Configuration;
    using System.Reflection;
    using System.Resources;

    public class ResourceManagerUtils
    {
        private static string resFile;
        private static string value;
        private static ResourceManager rm;

        public static string GetCurrentEnvironmentData(string key)
        {
            resFile = ConfigurationManager.AppSettings.Get("Environment");
            return GetValueFromResourceFile("SeleniumWebDriver.Resources.Data_" + resFile, key);
        }

        private static string GetValueFromResourceFile(string resourceFile, string key)
        {
            rm = new ResourceManager(resourceFile, Assembly.GetExecutingAssembly());

            try {
                value = rm.GetString(key); }
            catch (Exception e){
                throw new Exception($"Error happens during finding a key: '{key}';" +
                    $"\n Error:"+ e.Message);          
            }

            if (value == null) {
                throw new Exception ($"Unable to find a key's '{key}' value"); }
            else { return value; }
               
        }

    }
}
