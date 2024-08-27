using Dovs.WordPressAutoKit.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Dovs.WordPressAutoKit.Services
{
    /// <summary>
    /// Service for managing WebDriver instances.
    /// </summary>
    public class WebDriverService : IWebDriverService
    {
        /// <summary>
        /// Creates a new instance of the Chrome WebDriver.
        /// </summary>
        /// <returns>A new instance of <see cref="IWebDriver"/>.</returns>
        public IWebDriver CreateWebDriver()
        {
            return new ChromeDriver();
        }

        /// <summary>
        /// Quits the specified WebDriver instance.
        /// </summary>
        /// <param name="driver">The WebDriver instance to quit.</param>
        public void QuitWebDriver(IWebDriver driver)
        {
            driver.Quit();
        }
    }
}