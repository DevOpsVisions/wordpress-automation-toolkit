using OpenQA.Selenium;

namespace Dovs.WordPressAutoKit.Interfaces
{
    /// <summary>
    /// Interface for WebDriver service.
    /// </summary>
    public interface IWebDriverService
    {
        /// <summary>
        /// Creates a new WebDriver instance.
        /// </summary>
        /// <returns>A new instance of IWebDriver.</returns>
        IWebDriver CreateWebDriver();

        /// <summary>
        /// Quits the specified WebDriver instance.
        /// </summary>
        /// <param name="driver">The WebDriver instance to quit.</param>
        void QuitWebDriver(IWebDriver driver);
    }
}
