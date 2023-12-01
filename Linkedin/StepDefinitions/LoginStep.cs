using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace Linkedin.StepDefinitions
{
    [Binding]
    public class LoginStep
    {
        public static IWebDriver? driver;
        private IWebElement? passwordInput;

        [BeforeFeature]// Hooks
        public static void InitializeBrowser()
        {
            driver = new ChromeDriver();
        }
        
        [Given(@"User will be on the login page")]
        public void GivenUserWillBeOnTheLoginPage()
        {
            driver.Url = "https://www.Linkedin.com";
        }

        [AfterFeature]
        public static void Cleanup()
        {
            driver?.Quit();
        }
        [When(@"User will enter username '(.*)'")]
        public void WhenUserWillEnterTheUsername(string un)
        {
            DefaultWait<IWebDriver?> fluentwait = new DefaultWait<IWebDriver?>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(10);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element Not Found";

            IWebElement? emailInput = fluentwait.Until(driver => driver?.FindElement(By.Id("session_key")));
            emailInput?.SendKeys(un);
        }

        [When(@"User will enter password '(.*)'")]
        public void WhenUserWillEnterPassword(string pwd)
        {
            DefaultWait<IWebDriver?> fluentwait = new DefaultWait<IWebDriver?>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(10);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element Not Found";

            passwordInput = fluentwait.Until(driver => driver?.FindElement(By.Id("session_password")));
            passwordInput?.SendKeys(pwd);
            Console.WriteLine(passwordInput?.GetAttribute("value"));
        }

        [When(@"User will click on login button")]
        public void WhenUserWillClickOnLoginButton()
        {         
            IJavaScriptExecutor? js = (IJavaScriptExecutor?)driver;
            js?.ExecuteScript("arguments[0].scrollIntoView(true);", driver?.FindElement(By.XPath("//button[@type='submit']")));
            Thread.Sleep(5000);
            js?.ExecuteScript("arguments[0].click();", driver?.FindElement(By.XPath("//button[@type='submit']")));         
        }

        [Then(@"User will be redirected to Home page")]
        public void ThenUserWillBeRedirectedToHomePage()
        {
            Assert.That(driver.Title.Contains("Log In"));
        }
        [Then(@"Error message for Password Length should be thrown")]
        public void ThenErrorMessageForPasswordLengthShouldBeThrown()
        {
            IWebElement? alertPara = driver?.FindElement(By.XPath("//p[@for='session_password']"));
            string? alerttext = alertPara?.Text;
            Assert.That(alerttext.Equals("The password you provided must have at least 6 characters"));
        }
        [When(@"User will click on Show Link in the password textbox")]
        public void WhenUserWillClickOnShowLinkInThePasswordTextbox()
        {
            IWebElement showButton = driver.FindElement(By.XPath("//button[text()='Show']"));
            showButton.Click();
        }

        [Then(@"The password characters should be shown")]
        public void ThenThePasswordCharactersShouldBeShown()
        {
            Assert.That(passwordInput.GetAttribute("type").Equals("text"));
        }
        [When(@"User will click on Hide Link in the password textbox")]
        public void WhenUserWillClickOnHideLinkInThePasswordTextbox()
        {
            IWebElement hideButton = driver.FindElement(By.XPath("//button[text()='Hide']"));
            hideButton.Click();
        }

        [Then(@"The password characters should not be shown")]
        public void ThenThePasswordCharactersShouldNotBeShown()
        {
            Assert.That(passwordInput.GetAttribute("type").Equals("password"));
        }

    }
}
