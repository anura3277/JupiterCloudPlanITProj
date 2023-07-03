using OpenQA.Selenium;
using PlanitTestJupiterAutomation.Core;
using PlanitTestJupiterAutomation.PageComponents;
using PlanitTestJupiterAutomation.Models;

namespace PlanitTestJupiterAutomation.PageObjects
{
    internal class ContactPage :BasePage
    {

        private readonly By successAlert_locator = By.CssSelector(".alert.alert-success");
        private readonly By header_message_locator = By.CssSelector("#header-message");
        private readonly By form_container_locator = By.CssSelector("[name='form']");
        private readonly By submit_button_locator = By.CssSelector(".btn-contact.btn.btn-primary");
        IWebElement foreNameTextFieldElement => driver.FindElement(By.CssSelector("[ng-class*='form.forename']"));
        private By foreNameInPutLocator => By.CssSelector("[id='forename']");
        private By surnameInPutLocator => By.CssSelector("[id='surname']");
        IWebElement emailTextFieldElement => driver.FindElement(emailTextFieldLocator);
        private By emailTextFieldLocator => By.CssSelector("[ng-class*='form.email']");
        private By emailInPutLocator => By.CssSelector("[id='email']");
        private By telephoneInPutLocator => By.CssSelector("[id='telephone']");

        IWebElement alertElement => driver.FindElement(AreaLocator);
        private By AreaLocator => By.CssSelector("[class*='alert alert-']");

        private By messageTextAreaLocator => By.CssSelector("[ng-class*='form.message']"); 
        IWebElement messageTextAreaElement => driver.FindElement(messageTextAreaLocator); 
        private By messageInPutLocator => By.CssSelector("[id='message']");
        private IWebElement thanksAlert => driver.FindElement(thanksAlertlocator);
        private readonly By thanksAlertlocator = By.CssSelector(".alert.alert-success");

        private By errorMessageAlertLocator => By.CssSelector("[class='alert alert-error ng-scope']");
        private By errorMessageForenameLocator => By.CssSelector("[id='forename-err']");
        private By errorMessageEmailLocator => By.CssSelector("[id='email-err']");
        private By errorMessageMessageLocator => By.CssSelector("[id='message-err']");
        private By errorMessageLocator => By.CssSelector("[class*='help-inline']");


        IWebDriver driver;
        BasePage basePage;
        ContactPageComponents contactPageComponent;
        By locator;
        public ContactPage(IWebDriver webDriver) : base(webDriver)
        {
            this.driver = webDriver;
            contactPageComponent = new ContactPageComponents(webDriver,locator);
        }

        public void ClickSubmitButton() 
        {
            driver.WaitForElementToLoad(submit_button_locator);
            driver.FindElement(submit_button_locator).Click();
        }
        public string VerifyMandatoryFields( string field) 
        {
            string errorMessage= null;
            switch(field)
                {
                case "Alert":
                    {
                        errorMessage = GetMessage(errorMessageAlertLocator);
                    }
                    break;
                case "Forename":
                    {
                        errorMessage = GetMessage(errorMessageForenameLocator);
                    }
                    break;
                case "Email": 
                    {
                        errorMessage = GetMessage(errorMessageEmailLocator);
                    }
                    break;
                case "Message": 
                    {
                        errorMessage = GetMessage(errorMessageMessageLocator);
                    }
                    break;


                }
            return errorMessage;

        }

        public bool VerifyErrorMessageDisplayed(string field)
        {
            bool errorMessagePresent = false;
            switch (field)
            {
                case "Alert":
                    {
                        errorMessagePresent = IsMessageDisplayed(alertElement, errorMessageAlertLocator);
                    }
                    break;
                case "Forename":
                    {
                        errorMessagePresent = IsMessageDisplayed(foreNameTextFieldElement, errorMessageLocator);
                    }
                    break;
                case "Email":
                    {
                        errorMessagePresent = IsMessageDisplayed(emailTextFieldElement, errorMessageEmailLocator);
                    }
                    break;
                case "Message":
                    {
                        errorMessagePresent = IsMessageDisplayed(messageTextAreaElement, errorMessageMessageLocator);
                    }
                    break;


            }
            return errorMessagePresent;

        }

        public void FillContactPage(ContactForm contactForm)
        {
            if (!string.IsNullOrEmpty(contactForm.Forename))
            {
                Fill(foreNameInPutLocator, contactForm.Forename);
            }
            if (!string.IsNullOrEmpty(contactForm.Surname))
            {
                Fill(surnameInPutLocator, contactForm.Surname);
            }
            else 
            {
                Clear(surnameInPutLocator);
            }
            if (!string.IsNullOrEmpty(contactForm.Email))
            {
                Fill(emailInPutLocator, contactForm.Email);
            }
            if (!string.IsNullOrEmpty(contactForm.Telephone))
            {
                Fill(telephoneInPutLocator, contactForm.Telephone);
            }
            else
            {
                Clear(telephoneInPutLocator);
            }
            if (!string.IsNullOrEmpty(contactForm.Message))
            {
                Fill(messageInPutLocator, contactForm.Message);
            }

        }
        public string GetSubmitMessage()
        {
            driver.WaitForElementToLoad(thanksAlertlocator,30);
            return thanksAlert.Text;
        }
        public string GetMessage(By locator)
        {
            driver.WaitForElementToLoad(locator);
            return driver.FindElement(locator).Text;
        }

        public bool IsMessageDisplayed(IWebElement element,By locator)
        {
            return element.FindElements(locator).Any();
        }

        public void Fill(By locator, string value) 
        {
            driver.WaitForElementToLoad(locator);
            driver.FindElement(locator).SendKeys(value);
        }

        public void Clear(By locator)
        {
            driver.WaitForElementToLoad(locator);
            driver.FindElement(locator).Clear();
        }

    }
}
