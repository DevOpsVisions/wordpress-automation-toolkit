using OpenQA.Selenium;

namespace Dovs.WordPressAutoKit.Interfaces
{
    public interface IAdminLoginService
    {
        void Login(IWebDriver driver, string username, string password);
    }
}
