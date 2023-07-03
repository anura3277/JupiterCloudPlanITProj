using BoDi;
using OpenQA.Selenium;
using PlanitTestJupiterAutomation.Core;
using TechTalk.SpecFlow;

namespace PlanitTestJupiterAutomation.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private DriverBuilder builder;
        private readonly IObjectContainer objectContainer;
        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var testSettings = ConfigReader.GetSettings();
            builder = new DriverBuilder();
            var driver = builder.InitDriver(testSettings.Browser);
            objectContainer.RegisterInstanceAs(driver, typeof(IWebDriver));
        }

        [AfterScenario]
        public void AfterScenario()
        {
            builder.CloseWebDriver();
        }
    }
}