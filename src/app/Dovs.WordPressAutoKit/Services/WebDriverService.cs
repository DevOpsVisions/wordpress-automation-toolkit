using Dovs.WordPressAutoKit.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Dovs.WordPressAutoKit.Services
{
    public class WebDriverService : IWebDriverService
    {
        public IWebDriver CreateWebDriver()
        {
            return new ChromeDriver();
        }

        public void QuitWebDriver(IWebDriver driver)
        {
            driver.Quit();
        }
    }
}
