using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PlanitTestJupiterAutomation.Core
{
    internal class WebDriverFactory
    {
        public IWebDriver CreateChromeDriver() 
        {
            ChromeOptions options = new ChromeOptions();
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            return new ChromeDriver(options);
        }       
    }
}
