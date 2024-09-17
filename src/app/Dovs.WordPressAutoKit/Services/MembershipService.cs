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
            // Step 1: Click on the first <a> link with class 'button button-secondary' to redirect to the membership edit page
            var addMembershipFirstButton = driver.FindElement(By.CssSelector(ElementIds.ADD_MEMBERSHIP_FIRST_BUTTON));
            addMembershipFirstButton.Click();

            // Step 2: Click on the second <a> with class 'button-secondary pmpro-has-icon pmpro-has-icon-plus pmpro-member-change-level'
            var addMembershipSecondButton = driver.FindElement(By.CssSelector(ElementIds.ADD_MEMBERSHIP_SECOND_BUTTON));
            addMembershipSecondButton.Click();

            // Step 3: Choose the membership from the select dropdown by ID
            var membershipDropDown = driver.FindElement(By.Id(ElementIds.MEMBERSHIP_LEVEL_DROP));
            var selectElement = new SelectElement(membershipDropDown);
            selectElement.SelectByText(membershipLevel); // Choose the membership level

            // Step 4: Click on the button with class 'button button-primary' to save the changes
            var saveButton = driver.FindElement(By.CssSelector(ElementIds.ADD_MEMBERSHIP_SAVE_BUTTON));
            saveButton.Click();
        }
    }
}