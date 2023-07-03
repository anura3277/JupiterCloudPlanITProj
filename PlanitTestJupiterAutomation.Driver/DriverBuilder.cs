using OpenQA.Selenium;

namespace PlanitTestJupiterAutomation.Core
{
    public class DriverBuilder
    {
        private readonly WebDriverFactory factory;
        private IWebDriver driver;
        public DriverBuilder() : this(new WebDriverFactory())
        {
        
        }
        internal DriverBuilder(WebDriverFactory factory) 
        {
            this.factory = factory;
        }
        public IWebDriver InitDriver(string browserType) 
        {
            switch (browserType)
            {
                case "chrome":
                    {
                        driver = CreateWebDriver(BrowserType.CHROME);
                    }
                    break;
                default: 
                    {
                        driver = CreateWebDriver(BrowserType.CHROME);
                    }break;
            }
            
            return driver;
        }

        public void CloseWebDriver() 
        {
            if (driver != null) 
            {
                driver.Quit();
            }            
        }
        private IWebDriver CreateWebDriver(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.CHROME:
                    return factory.CreateChromeDriver();
                default:
                    throw new NotSupportedException($"{browserType} is not supported by your Browser type");
            }
        
        }
    }
}
