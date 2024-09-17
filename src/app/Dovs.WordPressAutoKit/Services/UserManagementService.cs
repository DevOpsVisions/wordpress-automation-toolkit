using Dovs.WordPressAutoKit.Interfaces;
using OpenQA.Selenium;
using Dovs.WordPressAutoKit.Common;

namespace Dovs.WordPressAutoKit.Services
{
    /// <summary>
    /// Service for managing user operations.
    /// </summary>
    public class UserManagementService : IUserManagementService
    {
        /// <summary>
        /// Adds a new user with the specified details.
        /// </summary>
        /// <param name="driver">The web driver used to interact with the web page.</param>
        /// <param name="userData">The user data containing user details.</param>
        /// <param name="password">The password for the new user.</param>
        public void AddNewUser(IWebDriver driver, UserData userData, string password,  string addNewUserUrl)
        {
            NavigateToAddNewUserPage(driver, addNewUserUrl);
            FillUserDetails(driver, userData, password);
            SubmitAddingForm(driver);
            NavigateToUrl(driver, GetConfirmationUrl(driver));
        }

        /// <summary>
        /// Navigates to the add new user page.
        /// </summary>
        /// <param name="driver">The web driver used to interact with the web page.</param>
        private void NavigateToAddNewUserPage(IWebDriver driver, string addNewUserUrl)
        {
            driver.Navigate().GoToUrl(addNewUserUrl);
        }

        /// <summary>
        /// Fills the user details in the form.
        /// </summary>
        /// <param name="driver">The web driver used to interact with the web page.</param>
        /// <param name="userData">The user data containing user details.</param>
        /// <param name="password">The password for the new user.</param>
        private void FillUserDetails(IWebDriver driver, UserData userData, string password)
        {
            FillBasicDetails(driver, userData);
            FillPassword(driver, password);
        }

        /// <summary>
        /// Fills the basic user details in the form.
        /// </summary>
        /// <param name="driver">The web driver used to interact with the web page.</param>
        /// <param name="userData">The user data containing user details.</param>
        private static void FillBasicDetails(IWebDriver driver, UserData userData)
        {
            driver.FindElement(By.Id(ElementIds.USER_NAME_INPUT)).SendKeys(userData.UserName);
            driver.FindElement(By.Id(ElementIds.EMAIL_INPUT)).SendKeys(userData.Email);

            string[] nameParts = userData.UserName.Split(new char[] { ' ' }, 2);
            string firstName = nameParts[0];
            string lastName = nameParts.Length > 1 ? nameParts[1] : "";

            driver.FindElement(By.Id(ElementIds.FIRST_NAME_INPUT)).SendKeys(firstName);
            driver.FindElement(By.Id(ElementIds.LAST_NAME_INPUT)).SendKeys(lastName);
        }

        /// <summary>
        /// Fills the password in the form.
        /// </summary>
        /// <param name="driver">The web driver used to interact with the web page.</param>
        /// <param name="password">The password for the new user.</param>
        private static void FillPassword(IWebDriver driver, string password)
        {
            var passwordField = driver.FindElement(By.Id(ElementIds.NEW_USER_PASSWORD_INPUT));
            passwordField.Clear();
            passwordField.SendKeys(password);
        }

        /// <summary>
        /// Submits the add new user form.
        /// </summary>
        /// <param name="driver">The web driver used to interact with the web page.</param>
        private static void SubmitAddingForm(IWebDriver driver)
        {
            driver.FindElement(By.Id(ElementIds.CREATE_USER_BUTTON)).Click();
            System.Threading.Thread.Sleep(1000);
        }

        /// <summary>
        /// Gets the confirmation URL after adding a new user.
        /// </summary>
        /// <param name="driver">The web driver used to interact with the web page.</param>
        /// <returns>The confirmation URL.</returns>
        private static string GetConfirmationUrl(IWebDriver driver)
        {
            var messageDiv = driver.FindElement(By.Id(ElementIds.CONFIRMATION_DIV));
            var anchorTag = messageDiv.FindElement(By.TagName(ElementIds.ANCHOR_TAG_NAME));
            return anchorTag.GetAttribute(ElementIds.ANCHOR_TAG_ATTRIBUTE);
        }

        /// <summary>
        /// Navigates to the specified URL.
        /// </summary>
        /// <param name="driver">The web driver used to interact with the web page.</param>
        /// <param name="url">The URL to navigate to.</param>
        private static void NavigateToUrl(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
            System.Threading.Thread.Sleep(1000);
        }
    }
}