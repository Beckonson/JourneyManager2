using JourneyManager2.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace JourneyManager2.StepDefinitions
{
    [Binding]
    public class InValidJourneyStepDefinitions
    {
        IWebDriver driver;
        [Given(@"User is om Tfl journey planning widget page")]
        public void GivenUserIsOmTflJourneyPlanningWidgetPage()
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

        [When(@"User Enter ""([^""]*)"" and ""([^""]*)"" and veryfy ""([^""]*)""")]
        public void WhenUserEnterAndAndVeryfy(string start, string destination, string outcome)
        {
            InValidJourneyPage invalidjourneyPage = new InValidJourneyPage(driver);
            
            invalidjourneyPage.inputFrom(start);
            invalidjourneyPage.inputTo(destination);
            invalidjourneyPage.ClickOnPlan();
            //IWebElement destfrom = driver.FindElement(By.Id("InputFrom"));
            //destfrom.SendKeys("ert34u");
            //IWebElement destTo = driver.FindElement(By.Id("InputTo"));
            //destTo.SendKeys("edgsg");
            //IWebElement planbutton = driver.FindElement(By.XPath("//input[@id='plan-journey-button']"));
            //planbutton.Click();

            IWebElement invalidLoc = driver.FindElement(By.CssSelector("div[class='from-results disambiguation-wrapper clearfix'] div[class='info-message disambiguation'] span"));
            string invalidLocText = invalidLoc.Text;
            Console.WriteLine(invalidLocText);
            Assert.Equal(outcome, invalidLocText);
            

            IWebElement errorMessge1 = driver.FindElement(By.XPath("//span[@id='InputFrom-error']"));
            string errorMessge1Text = errorMessge1.Text;
            IWebElement errorMessge2 = driver.FindElement(By.XPath("//span[@id='InputTo-error']"));
            string errorMessge2Text = errorMessge1.Text;

            Assert.Equal(outcome,errorMessge1Text);
            Assert.Equal(outcome,errorMessge2Text);
 
        }
    }
}


    

