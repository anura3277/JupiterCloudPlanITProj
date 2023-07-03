using OpenQA.Selenium;

namespace PlanitTestJupiterAutomation.PageComponents
{
    internal class ContactPageComponents : BasePageComponents
    {
        IWebDriver driver;
        private By locator { get; set; }
        private IWebElement parentElement => driver.FindElement(locator);
        private By inputFeildLocator => By.CssSelector("input");
        private IWebElement inputField => parentElement.FindElement(inputFeildLocator);
        private By errorMessageLocator => By.CssSelector(" [id='forename-err']");
        private IWebElement errormessage => parentElement.FindElement(errorMessageLocator);
        private By itemTitleLocator => By.CssSelector("h4");
        private IWebElement ItemTitle => parentElement.FindElement(itemTitleLocator);
        private By productBuybuttonLocator => By.CssSelector(".btn");
        private IWebElement selectItemButton => parentElement.FindElement(productBuybuttonLocator);
        private By _textAreaLocator => By.CssSelector("textarea");
        private IWebElement textField => parentElement.FindElement(_textAreaLocator);
        private By _errorMessageLocator => By.CssSelector("span.help-inline");



        public ContactPageComponents(IWebDriver webDriver, By locator) : base(webDriver)
        {
            this.driver = webDriver;
        }
     
    }
}
