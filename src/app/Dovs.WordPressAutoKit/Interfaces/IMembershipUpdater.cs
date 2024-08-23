using OpenQA.Selenium;

namespace Dovs.WordPressAutoKit.Interfaces
{
    public interface IMembershipUpdater
    {
        void UpdateMembershipLevel(IWebDriver driver, string membershipLevel);
    }
}
