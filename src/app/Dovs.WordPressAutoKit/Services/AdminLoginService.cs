using Dovs.WordPressAutoKit.Interfaces;
using OpenQA.Selenium;
using Dovs.WordPressAutoKit.Common;


namespace Dovs.WordPressAutoKit.Services
{
    public class AdminLoginService : IAdminLoginService
    {
        private readonly IConfigurationService _configurationService;

        public AdminLoginService(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public void Login(IWebDriver driver, string username, string password)
        {
            driver.Navigate().GoToUrl(_configurationService.GetConfigValue("LoginUrl"));
            FillLoginForm(driver, username, password);
            ClickLoginButton(driver);
            System.Threading.Thread.Sleep(1000);
        }

        private void FillLoginForm(IWebDriver driver, string username, string password)
        {
            driver.FindElement(By.Id(ElementIds.USERNAMEINPUT)).SendKeys(username);
            driver.FindElement(By.Id(ElementIds.LOGINPASSWORDINPUT)).SendKeys(password);
        }

        private void ClickLoginButton(IWebDriver driver)
        {
            driver.FindElement(By.Id(ElementIds.LOGINBUTTON)).Click();
        }
    }
}
