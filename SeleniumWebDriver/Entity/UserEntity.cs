
namespace SeleniumWebDriver.Data
{
    using System;
    using SeleniumWebDriver.Entity;
    using SeleniumWebDriver.Utils;

    public class UserEntity : ILoginable
    {      
        public string Email { get ; set; } 
        public string Password { get ; set ;  }

        public UserEntity()
        {
        }

        public ILoginable GetNewUserInfo() {

            return GetCurrentUserFromData("new");
        }

        public ILoginable GetDefaultUserInfo()
        {
            return GetCurrentUserFromData("default");
        }

        private ILoginable GetCurrentUserFromData(string prefix)
        {
            ILoginable user = new UserEntity
            {
                Email = ResourceManagerUtils.GetCurrentEnvironmentData(prefix + "_email"),
                Password = ResourceManagerUtils.GetCurrentEnvironmentData(prefix + "_password")
            };
            return user;
        }

    }
}
