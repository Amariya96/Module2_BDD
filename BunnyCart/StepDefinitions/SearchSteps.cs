using BunnyCart.Hooks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;
using System;
using TechTalk.SpecFlow;

namespace BunnyCart.StepDefinitions
{
    [Binding]
    public class SearchSteps : CoreCodes
    {
       IWebDriver? driver = BeforeHooks.driver;

        [Given(@"User will be on the HomePage")]
        public void GivenUserWillBeOnTheHomePage()
        {
            driver.Url = "https://www.bunnycart.com";
            driver.Manage().Window.Maximize();
        }

        [When(@"User will type the '([^']*)' in the searchbox")]
        public void WhenUserWillTypeTheInTheSearchbox(string searchtext)
        {

            IWebElement? searchInput = driver?.FindElement(By.Id("search"));
            searchInput?.SendKeys(searchtext);
            Log.Information("Typed search text" + searchtext);
            searchInput?.SendKeys(Keys.Enter);
        }

        /*[When(@"User clicks on search button")]
        public void WhenUserClicksOnSearchButton()
        {
            IWebElement? searchButton = driver?.FindElement(By.XPath("//button[@title='Search']"));
            searchButton?.Click();
        }*/

        [Then(@"Search results are loaded in the same page with '([^']*)'")]
        public void ThenSearchResultsAreLoadedInTheSamePageWith(string searchtext)
        {
            
            TakeScreenshot(driver);
            Log.Information("SS taken");
            try { 
                Assert.That(driver.Url.Contains(searchtext));
                LogTestResult("Search Test", " Seacrh Test Success");
            }
            catch(AssertionException ex)
            {
                LogTestResult("Search Test", " Seacrh Test Failed", ex.Message);
            }

        }
        [Then(@"The heading should have the '([^']*)'")]
        public void ThenTheHeadingShouldHaveThe(string searchtext)
        {
            IWebElement? searchheading = driver?.FindElement(By.XPath("//h1[@class='page-title']"));
            Assert.That(searchtext, Does.Contain(searchheading?.Text));
        }

        [Then(@"Title should have '([^']*)'")]
        public void ThenTitleShouldHave(string searchtext)
        {
            Assert.That(searchtext, Does.Contain(driver?.Title));
        }
    }
}
