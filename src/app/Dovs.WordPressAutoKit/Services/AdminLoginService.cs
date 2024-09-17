using Dovs.WordPressAutoKit.Interfaces;
using OpenQA.Selenium;
using Dovs.WordPressAutoKit.Common;

namespace Dovs.WordPressAutoKit.Services
{
    /// <summary>  
    /// Service for handling admin login operations.  
    /// </summary>  
    public class AdminLoginService : IAdminLoginService
    {
        /// <summary>  
        /// Logs in to the admin panel using the provided WebDriver, username, and password.  
        /// </summary>  
        /// <param name="driver">The WebDriver instance used to perform the login.</param>  
        /// <param name="username">The admin username.</param>  
        /// <param name="password">The admin password.</param>  
        public void Login(IWebDriver driver, string loginUrl, string username, string password)
        {
            driver.Navigate().GoToUrl(loginUrl);
            FillLoginForm(driver, username, password);
            ClickLoginButton(driver);
            System.Threading.Thread.Sleep(1000);
        }

        /// <summary>  
        /// Fills the login form with the provided username and password.  
        /// </summary>  
        /// <param name="driver">The WebDriver instance used to fill the form.</param>  
        /// <param name="username">The admin username.</param>  
        /// <param name="password">The admin password.</param>  
        private void FillLoginForm(IWebDriver driver, string username, string password)
        {
            driver.FindElement(By.Id(ElementIds.USER_NAME_INPUT)).SendKeys(username);
            driver.FindElement(By.Id(ElementIds.USER_PASS_INPUT)).SendKeys(password);
        }

        /// <summary>  
        /// Clicks the login button to submit the login form.  
        /// </summary>  
        /// <param name="driver">The WebDriver instance used to click the button.</param>  
        private void ClickLoginButton(IWebDriver driver)
        {
            driver.FindElement(By.Id(ElementIds.LOGIN_BUTTON)).Click();
        }
    }
}