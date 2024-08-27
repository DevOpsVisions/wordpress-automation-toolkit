using Dovs.WordPressAutoKit.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Dovs.WordPressAutoKit.Common;

namespace Dovs.WordPressAutoKit.Services
{
    /// <summary>
    /// Service for handling membership level updates.
    /// </summary>
    public class MembershipService : IMembershipService
    {
        /// <summary>
        /// Updates the membership level using the specified web driver.
        /// </summary>
        /// <param name="driver">The web driver used to interact with the web page.</param>
        /// <param name="membershipLevel">The membership level to select.</param>
        public void UpdateMembershipLevel(IWebDriver driver, string membershipLevel)
        {
            var membershipLevelDrop = driver.FindElement(By.Name(ElementIds.MEMBERSHIP_LEVEL_DROP));
            var selectElement = new SelectElement(membershipLevelDrop);
            selectElement.SelectByText(membershipLevel);
        }
    }
}