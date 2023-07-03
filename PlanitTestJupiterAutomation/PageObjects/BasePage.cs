using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PlanitTestJupiterAutomation.Core;
using PlanitTestJupiterAutomation.Models;

namespace PlanitTestJupiterAutomation.PageObjects
{
    internal class BasePage
    {
        internal readonly IWebDriver driver;
        internal readonly WebDriverWait wait;
        internal TestSettings settings;

        public static By contactPage = By.CssSelector("#nav-contact");
        public static By shopPage = By.CssSelector("[id='nav-shop']");
        public static By cartPage = By.CssSelector("[id='nav-cart']");


        public BasePage(IWebDriver driver) 
        {

            settings = ConfigReader.GetSettings();
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(settings.Timeout));
        }

        public void Load(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.WaitForPageLoad();
        }

        public string ReturnPageTitle() => driver.Title;
        public void GoToPage(string pageName)
        {
            switch (pageName)
            {
                case "Contact":
                    {
                        driver.FindElement(contactPage).Click();
                        driver.WaitForPageLoad();
                    }
                    break;
                case "Shop":
                    {
                        driver.FindElement(shopPage).Click();
                        driver.WaitForPageLoad();
                        driver.Manage().Window.Maximize();
                    }
                    break;
                case "Cart":
                    {
                        driver.WaitForPageLoad();
                        driver.FindElement(cartPage).Click();
                        Thread.Sleep(5000);
                        
                    }
                    break;
            }  
        }

    }
}
