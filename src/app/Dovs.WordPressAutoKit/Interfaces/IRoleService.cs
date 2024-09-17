
using OpenQA.Selenium;

namespace Dovs.WordPressAutoKit.Interfaces
{
    public interface IRoleService
    {
        void UpdateRole(IWebDriver driver, string role);
    }
}
