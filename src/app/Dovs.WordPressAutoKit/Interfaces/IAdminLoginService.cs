
using OpenQA.Selenium;

namespace Dovs.WordPressAutoKit.Interfaces
{
    /// <summary>
    /// Interface for admin login service.
    /// </summary>
    public interface IAdminLoginService
    {
        /// <summary>
        /// Logs in to the admin panel using the provided WebDriver, username, and password.
        /// </summary>
        /// <param name="driver">The WebDriver instance used to perform the login.</param>
        /// <param name="username">The admin username.</param>
        /// <param name="password">The admin password.</param>
        void Login(IWebDriver driver, string loginUrl, string username, string password);
    }
}
