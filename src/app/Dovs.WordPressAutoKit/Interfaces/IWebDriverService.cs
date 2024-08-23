using OpenQA.Selenium;

namespace Dovs.WordPressAutoKit.Interfaces
{
    public interface IWebDriverService
    {
        IWebDriver CreateWebDriver();
        void QuitWebDriver(IWebDriver driver);
    }
}
