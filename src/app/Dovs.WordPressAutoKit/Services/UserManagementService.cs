using Dovs.WordPressAutoKit.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Dovs.WordPressAutoKit.Common;

namespace Dovs.WordPressAutoKit.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IMembershipUpdater _membershipUpdater;
        private readonly IConfigurationService _configurationService;

        public UserManagementService(IMembershipUpdater membershipUpdater, IConfigurationService configurationService)
        {
            _membershipUpdater = membershipUpdater;
            _configurationService = configurationService;
        }

        public void AddNewUser(IWebDriver driver, UserData userData, string password)
        {
            NavigateToAddNewUserPage(driver);
            FillUserDetails(driver, userData, password);
            SubmitAddingForm(driver);
            string confirmationUrl = GetConfirmationUrl(driver);
            NavigateToUrl(driver, confirmationUrl);
            string postRegisterRole = GetConfigValue("PostRegisterRole");
            UpdateUserRole(driver, postRegisterRole);
            _membershipUpdater.UpdateMembershipLevel(driver, userData.Membership);
            SaveChanges(driver);
        }

        private void NavigateToAddNewUserPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(GetConfigValue("AddNewUserUrl"));
        }

        private void FillUserDetails(IWebDriver driver, UserData userData, string password)
        {
            FillBasicDetails(driver, userData);
            FillPassword(driver, password);
            string preRegisterRole = GetConfigValue("PreRegisterRole");
            SelectUserRole(driver, preRegisterRole); 
        }

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

        private static void FillPassword(IWebDriver driver, string password)
        {
            var passwordField = driver.FindElement(By.Id(ElementIds.NEW_USER_PASSWORD_INPUT));
            passwordField.Clear();
            passwordField.SendKeys(password);
        }

        private static void SelectUserRole(IWebDriver driver, string role)
        {
            var roleDropdown = driver.FindElement(By.Id(ElementIds.ROLE_SELECTION));
            var selectElement = new SelectElement(roleDropdown);
            selectElement.SelectByValue(role);
        }

        private static void SubmitAddingForm(IWebDriver driver)
        {
            driver.FindElement(By.Id(ElementIds.CREATE_USER_BUTTON)).Click();
            System.Threading.Thread.Sleep(1000);
        }

        private static string GetConfirmationUrl(IWebDriver driver)
        {
            var messageDiv = driver.FindElement(By.Id(ElementIds.CONFIRMATION_DIV));
            var anchorTag = messageDiv.FindElement(By.TagName(ElementIds.ANCHOR_TAG_NAME));
            return anchorTag.GetAttribute(ElementIds.ANCHOR_TAG_ATTRIBUTE);
        }

        private static void NavigateToUrl(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
            System.Threading.Thread.Sleep(1000);
        }

        private static void UpdateUserRole(IWebDriver driver, string role)
        {
            var roleDropdown = driver.FindElement(By.Id(ElementIds.ROLE_SELECTION));
            var selectElement = new SelectElement(roleDropdown);
            selectElement.SelectByValue(role);
        }

        private static void SaveChanges(IWebDriver driver)
        {
            driver.FindElement(By.Id(ElementIds.UPDATE_USER_BUTTON)).Click();
            System.Threading.Thread.Sleep(1000);
        }

        private string GetConfigValue(string key)
        {
            return _configurationService.GetConfigValue(key);
        }
    }
}
