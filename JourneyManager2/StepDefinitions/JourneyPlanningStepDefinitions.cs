using JourneyManager2.Pages;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace JourneyManager2.StepDefinitions
{
    [Binding]
    public class JourneyPlanningStepDefinitions
    {
        IWebDriver driver;
        

        [Given(@"User navigate to Tfl journey planning widget page")]
        public void GivenUserNavigateToTflJourneyPlanningWidgetPage()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://tfl.gov.uk/plan-a-journey/");

            HandleCookiesPopup();
        }
        private void HandleCookiesPopup()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                var acceptCookiesButton = wait.Until(d => d.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll")));


                if (acceptCookiesButton.Displayed)
                {
                    acceptCookiesButton.Click();
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Cookies pop-up not found. Continuing with test execution.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Timed out waiting for cookies pop-up. Continuing with test execution.");
            }
        }

        [When(@"User enter a starting point")]
        public void WhenUserEnterAStartingPoint()
        {
            JourneyPlanningPage journeyplanningPage = new JourneyPlanningPage(driver);
            journeyplanningPage.EnterDesinationFrom("Leicester");
            Thread.Sleep(100);
            journeyplanningPage.SelectDestinationFrom();

            //IWebElement suggestion = driver.FindElement(By.Id("stop-points-search-suggestion-0"));
            // Click on the desired suggestion
            //suggestion.Click();
        }
        [When(@"User enter destination point")]
        public void WhenUserEnterDestinationPoint()
        {
            JourneyPlanningPage journeyplanningPage = new JourneyPlanningPage(driver);
            journeyplanningPage.EnterDestinationTo("Covent");
            Thread.Sleep(100);
            journeyplanningPage.SelectDestinationTo();

            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //IWebElement destSuggestion = wait.Until(d => d.FindElement(By.Id("stop-points-search-suggestion-0")));
            //IWebElement destSuggestion = driver.FindElement(By.Id("stop-points-search-suggestion-0"));
            //Click on the desired suggestion
            //destSuggestion.Click();    
        }

        [When(@"Click the Plan my journey  button")]
        public void WhenClickThePlanMyJourneyButton()
        {
            JourneyPlanningPage journeyplanningPage = new JourneyPlanningPage(driver);
            journeyplanningPage.ClickOnPlanButtom();
            
            //IWebElement planbutton = driver.FindElement(By.XPath("//input[@id='plan-journey-button']"));
            //planbutton.Click();

        }

        [Then(@"User should see a valid journey result  displayed")]
        public void ThenUserShouldSeeAValidJourneyResultDisplayed()
        {
            // Validate the result for both walking and cycling time

            JourneyPlanningPage journeyplanningPage = new JourneyPlanningPage(driver);
            Assert.IsTrue(journeyplanningPage.IsCyclingOptionDisplay(), "cycling result was not displayed");
            Assert.IsTrue(journeyplanningPage.IsWalkingOptionDisplay(), "cycling result was not displayed");

            driver.Quit();
        }

        [When(@"User click the Edit preferences")]
        public void WhenUserClickTheEditPreferences()
        {
            JourneyPlanningPage journeyplanningPage = new JourneyPlanningPage(driver);
            journeyplanningPage.SetPref();

            //IWebElement editPreference = driver.FindElement(By.XPath("//button[@class='toggle-options more-options']"));
            //editPreference.Click();
        }

        [When(@"Select Routes with least walking")]
        public void WhenSelectRoutesWithLeastWalking()
        {
            JourneyPlanningPage journeyplanningPage = new JourneyPlanningPage(driver);
            journeyplanningPage.chooseRout();

            //IWebElement choiceRoute = driver.FindElement(By.XPath("//label[@for='JourneyPreference_2']"));
            //choiceRoute.Click();
        }
        [When(@"Click on Update Journey")]
        public void WhenClickOnUpdateJourney()
        {
            JourneyPlanningPage journeyplanningPage = new JourneyPlanningPage(driver);
            journeyplanningPage.updteRout();

            //IWebElement updateRoute = driver.FindElement(By.XPath("//div[@id='more-journey-options']//div//input[@value='Update journey']"));
            //updateRoute.Click();
            //IWebElement journeyTime = driver.FindElement(By.XPath("//div[@id='option-1-heading']//div[@class='journey-time no-map']"));

            Assert.IsTrue(journeyplanningPage.IsjourneyTimDisplay(), "Journey map time was not displayed");

        }

        [Then(@"User should see a route details")]
        public void ThenUserShouldSeeARouteDetails()
        {
            JourneyPlanningPage journeyplanningPage = new JourneyPlanningPage(driver);
            journeyplanningPage.details();

            //IWebElement detailView = driver.FindElement(By.CssSelector("div[id='option-1-content'] button[class='secondary-button show-detailed-results view-hide-details']"));
            //detailView.Click();
        }

        [Then(@"User can Verify complete access information")]
        public void ThenUserCanVerifyCompleteAccessInformation()
        {
            //IWebElement stairs = driver.FindElement(By.XPath("//div[@class='access-information']//a[@aria-label='Up stairs']"));
            //IWebElement upLift = driver.FindElement(By.XPath("//div[@class='access-information']//a[@aria-label='Up lift']"));
            //IWebElement levelWalk = driver.FindElement(By.XPath("//div[@class='access-information']//a[@aria-label='Level walkway']"));

            JourneyPlanningPage journeyplanningPage = new JourneyPlanningPage(driver);
            Assert.IsTrue(journeyplanningPage.IsStairDisplay(), "up stair walk was not displayed");
            Assert.IsTrue(journeyplanningPage.IsLiftDisplay(), "up lift image was not displayed");
            Assert.IsTrue(journeyplanningPage.IslevelWalkDisplay(), "levelWalk image was not displayed");

            

        }

    }
}
