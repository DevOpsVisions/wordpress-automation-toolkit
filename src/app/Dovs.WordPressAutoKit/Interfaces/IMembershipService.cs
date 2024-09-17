using OpenQA.Selenium;

namespace Dovs.WordPressAutoKit.Interfaces
{
    /// <summary>
    /// Interface for membership service.
    /// </summary>
    public interface IMembershipService
    {
        /// <summary>
        /// Updates the membership level of a user.
        /// </summary>
        /// <param name="driver">The WebDriver instance used to perform the update.</param>
        /// <param name="membershipLevel">The new membership level to be assigned.</param>
        void AddMembership(IWebDriver driver, string membershipLevel);
    }
}
