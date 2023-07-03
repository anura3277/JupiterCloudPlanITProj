using NUnit.Framework;
using OpenQA.Selenium;
using PlanitTestJupiterAutomation.Models;
using PlanitTestJupiterAutomation.PageObjects;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace PlanitTestJupiterAutomation.StepDefinitions
{
    [Binding]
    public class ContactStepDef
    { 
        private ScenarioContext context;
        private readonly HomePage homePage;
        private readonly ContactPage contactPage;
        public ContactStepDef(ScenarioContext context, IWebDriver driver)
        {
            this.context= context;
            homePage = new HomePage(driver);
            contactPage = new ContactPage(driver);
        }

        [StepDefinition(@"I load Jupiter home page")]
        public void GivenILoadJupiterHomePage()
        {
            homePage.Load();
        }
        
        [StepDefinition(@"I navigate to Contact page")]
        public void GivenINavigateToContactPage()
        {
            homePage.GoToPage("Contact");
        }

        [StepDefinition(@"I click ""Submit"" button on Contact Page")]
        public void WhenIClickSubmitButtonOnContactPage()
        {
            contactPage.ClickSubmitButton();
        }


        [StepDefinition(@"I verify error messages are appeared")]
        public void ThenIVerifyErrorMessagesAreAppeared()
        {
            Assert.That(contactPage.VerifyMandatoryFields("Alert"), Is.EqualTo("We welcome your feedback - but we won't get it unless you complete the form correctly."), message: "Alert Error message is wrong");
            Assert.That(contactPage.VerifyMandatoryFields("Forename"), Is.EqualTo("Forename is required"), message: "Forename Error message is wrong");
            Assert.That(contactPage.VerifyMandatoryFields("Email"), Is.EqualTo("Email is required"), message: "Email Error message is wrong");
            Assert.That(contactPage.VerifyMandatoryFields("Message"), Is.EqualTo("Message is required"), message: "Message Error message is wrong");                      
        }

        [StepDefinition(@"I enter values to Mandatory fields")]
        public void ThenIEnterValuesToMandatoryFields(Table table)
        {
            var tableData = table.CreateInstance<ContactForm>();
            contactPage.FillContactPage(tableData);
        }

        [StepDefinition(@"I verify the error messages are gone")]
        public void ThenIVerifyTheErrorMessagesAreGone()
        {
            Assert.That(contactPage.VerifyErrorMessageDisplayed("Alert"), Is.False, message: "Alert Error Message still displayed");
            Assert.That(contactPage.VerifyErrorMessageDisplayed("Forename"), Is.False, message: "Forename Error Message still displayed");
            Assert.That(contactPage.VerifyErrorMessageDisplayed("Email"), Is.False, message: "Email Error Message still displayed");
            Assert.That(contactPage.VerifyErrorMessageDisplayed("Message"), Is.False, message: "Message Error Message still displayed");
        }

        [StepDefinition(@"I verify the successful submission message")]
        public void ThenIVerifyTheSuccessfulSubmissionMessage()
        {
            Assert.That(contactPage.GetSubmitMessage(), Is.EqualTo($"Thanks {context["ForeName"]}, we appreciate your feedback."), message: "Submit confirmation message is wrong");
            Console.WriteLine("Submit verified");
        }
        [When(@"I enter values to (.*),(.*),(.*)")]
        public void WhenIEnterValuesToAnuraAnuraGmail_ComTestMessageForAnuraFields(string Forename, string Email, string Message)
        {
            var tableData = new ContactForm();
            tableData.Forename = Forename;
            tableData.Email = Email;
            tableData.Message = Message;
            context["ForeName"] = Forename;

            contactPage.FillContactPage(tableData);
        }

    }

}