using OpenQA.Selenium;

namespace Dovs.WordPressAutoKit.Interfaces
{
    public interface IUserManagementService
    {
        void AddNewUser(IWebDriver driver, UserData userData, string password);
    }
}
