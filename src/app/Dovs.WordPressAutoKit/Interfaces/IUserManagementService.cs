using OpenQA.Selenium;

namespace Dovs.WordPressAutoKit.Interfaces
{
    /// <summary>
    /// Interface for user management service.
    /// </summary>
    public interface IUserManagementService
    {
        /// <summary>
        /// Adds a new user to the system.
        /// </summary>
        /// <param name="driver">The WebDriver instance used to perform the operation.</param>
        /// <param name="userData">The data of the user to be added.</param>
        /// <param name="password">The password for the new user.</param>
        void AddNewUser(IWebDriver driver, UserData userData, string password);
    }
}
