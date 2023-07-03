using OpenQA.Selenium;

namespace PlanitTestJupiterAutomation.PageObjects
{
    internal class HomePage :BasePage
    {
        public static By contactTab = By.CssSelector("#nav-contact");

        public HomePage(IWebDriver driver) : base(driver)
        {
        }
        public void Load() => Load(settings.Url); 

 
    }
}
