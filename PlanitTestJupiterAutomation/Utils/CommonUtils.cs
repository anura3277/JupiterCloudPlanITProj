using NUnit.Framework;
using OpenQA.Selenium;

namespace PlanitTestJupiterAutomation.Utils
{
    public class CommonUtils
    {
        public void LogWriter(string LogType, IWebDriver driver)
        {
            var _logs = driver.Manage().Logs;
            try
            {
                var browserLogs = _logs.GetLog(LogType);
                if (browserLogs.Count > 0)
                {
                    var path = $"{Path.GetTempPath()} ConsoleLogs --{Guid.NewGuid()}.txt";
                    File.WriteAllText(path, "Begining of the Log:");

                    foreach (var log in browserLogs)
                    {
                        StreamWriter writer = File.AppendText(path);
                        writer.WriteLine(log.ToString());
                        writer.Close();
                    }
                    TestContext.AddTestAttachment(path, "Console Logs");
                }
            }
            catch
            {
                Console.WriteLine("No logs found to write");
            }
        }
    }
}
