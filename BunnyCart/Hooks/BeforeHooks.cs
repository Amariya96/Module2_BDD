
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;
using TechTalk.SpecFlow;

namespace BunnyCart.Hooks
{
    [Binding]
    public sealed class BeforeHooks
    {
        public static IWebDriver? driver;

        [BeforeFeature]// Hooks
        public static void InitializeBrowser()
        {
            driver = new ChromeDriver();
        }
        [AfterFeature]
        public static void CleanupBrowser()
        {
            driver?.Quit();
        }
        [BeforeFeature]
        public static void LogFiles()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/SearchFeature" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration().WriteTo.Console().
                WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day).CreateLogger();
        }
        [AfterScenario]
        public static void NavigateToHomePage()
        {
            driver?.Navigate().GoToUrl("https://www.bunnycart.com");
            driver?.Manage().Window.Maximize();
        }
    }
}