using Dovs.WordPressAutoKit.Common;
using Dovs.WordPressAutoKit.Interfaces;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Dovs.WordPressAutoKit.Services
{
    public class RoleService : IRoleService
    {
        /// <summary>
        /// Updates the user role.
        /// </summary>
        /// <param name="driver">The web driver used to interact with the web page.</param>
        /// <param name="role">The role to update to.</param>
        public void UpdateRole(IWebDriver driver, string role)
        {
            SelectRole(driver, role);
            SaveChanges(driver);
        }

        /// <summary>
        /// Selects the user role from the dropdown.
        /// </summary>
        /// <param name="driver">The web driver used to interact with the web page.</param>
        /// <param name="role">The role to select.</param>
        private static void SelectRole(IWebDriver driver, string role)
        {
            var roleDropdown = driver.FindElement(By.Id(ElementIds.ROLE_SELECTION));
            var selectElement = new SelectElement(roleDropdown);
            selectElement.SelectByValue(role);
        }

        /// <summary>
        /// Saves the changes made to the user.
        /// </summary>
        /// <param name="driver">The web driver used to interact with the web page.</param>
        private static void SaveChanges(IWebDriver driver)
        {
            driver.FindElement(By.Id(ElementIds.UPDATE_USER_BUTTON)).Click();
            System.Threading.Thread.Sleep(1000);
        }
    }
}
