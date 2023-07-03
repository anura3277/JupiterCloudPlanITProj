using Microsoft.Extensions.Configuration;
using PlanitTestJupiterAutomation.Models;

namespace PlanitTestJupiterAutomation
{
    public class ConfigReader
    {
        public static TestSettings GetSettings() 
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json");
            IConfigurationRoot configuration = builder.Build();
            var testSettings = configuration.Get<TestSettings>();
            return testSettings;
        }
    }
}
