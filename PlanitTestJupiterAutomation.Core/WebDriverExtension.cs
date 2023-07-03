using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace PlanitTestJupiterAutomation.Core
{
    public static class WebDriverExtension
    {
        public static void WaitForPageLoad(this IWebDriver driver, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            wait.Until(driver =>
            {
                bool isPageLoaded = (driver as IJavaScriptExecutor)?.ExecuteScript("return document.readyState").Equals("complete") ?? false;
                return isPageLoaded; 
            });
        }
        public static void WaitForElementToLoad(this IWebDriver driver, By elementLocator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLocator));
        }
        public static void WaitForElementToLoad(this IWebDriver driver, By elementLocator,int time)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLocator));
        }
    }
}
