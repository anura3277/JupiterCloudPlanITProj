using OpenQA.Selenium;

namespace PlanitTestJupiterAutomation.PageComponents
{
    public class BasePageComponents
    {
        IWebDriver driver;
        public BasePageComponents(IWebDriver webDriver) 
        {
            this.driver = webDriver;
        }
    }
}
