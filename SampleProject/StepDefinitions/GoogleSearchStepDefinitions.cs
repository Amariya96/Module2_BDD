using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace SampleProject.StepDefinitions
{
    [Binding]
    public class GoogleSearchStepDefinitions
    {
        public IWebDriver driver;

        [BeforeScenario] 
        public void InitializeBrowser()
        {
         driver = new ChromeDriver();
        }
        [AfterScenario]
        public void CleanupBrowser()
        {
            driver?.Quit();
        }
        [Given(@"Google home page should be loaded")] //@ - identification of attribute
        public void GivenGoogleHomePageShouldBeLoaded()
        {
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();
        }

        [When(@"Type ""([^""]*)"" in the search text input")]
        public void WhenTypeInTheSearchTextInput(string searchtext)
        {
            IWebElement searchInput = driver.FindElement(By.Id("APjFqb"));
            searchInput.SendKeys(searchtext);
        }

        [When(@"Click on the Google Search button")]
        public void WhenClickOnTheGoogleSearchButton()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(5);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element Not Found";

            IWebElement? gsb = fluentwait.Until(d =>
            {
                IWebElement? searchButton = driver?.FindElement(By.Name("btnK"));
                return searchButton.Displayed ? searchButton : null;
            });
            if (gsb != null)
            {
                gsb.Click();
            }
        }
       
        [Then(@"the results should be displayed on the next page with title ""(.*)""")]
        public void ThenTheResultsShouldBeDisplayedOnTheNextPageWithTitle(string title)
        {
            Assert.That(driver.Title, Is.EqualTo(title));
        }
        [When(@"Click on the IMFL button")]
        public void WhenClickOnTheIMFLButton()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(5);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element Not Found";

            IWebElement? imfl = fluentwait.Until(d =>
            {
                IWebElement? searchButton = driver?.FindElement(By.Name("btnI"));
                return searchButton.Displayed ? searchButton : null;
            });
            if (imfl != null)
            {
                imfl.Click();
            }
        }

        [Then(@"the results should be redirected to a new page with title ""([^""]*)""")]
        public void ThenTheResultsShouldBeRedirectedToANewPageWithTitle(string title)
        {
            Assert.That(driver.Title.Contains(title));
        }

    }
}
