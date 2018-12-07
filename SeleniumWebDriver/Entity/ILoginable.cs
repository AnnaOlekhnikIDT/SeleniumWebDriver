namespace SeleniumWebDriver.Entity
{
    using SeleniumWebDriver.Data;
    
    public interface ILoginable
    {
        string Email { get; set; }
        string Password { get; set; }

        ILoginable GetNewUserInfo();
        ILoginable GetDefaultUserInfo();
    }
}
