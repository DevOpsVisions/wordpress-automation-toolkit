using Dovs.WordPressAutoKit.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Dovs.WordPressAutoKit.Common;

namespace Dovs.WordPressAutoKit.Services
{
    public class MembershipUpdater : IMembershipUpdater
    {
        public void UpdateMembershipLevel(IWebDriver driver, string membershipLevel)
        {
            var membershipLevelDrop = driver.FindElement(By.Name(ElementIds.MEMBERSHIPLEVELDROP));
            var selectElement = new SelectElement(membershipLevelDrop);
            selectElement.SelectByText(membershipLevel);
        }
    }
}
