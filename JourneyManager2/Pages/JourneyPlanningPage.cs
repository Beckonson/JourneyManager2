using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyManager2.Pages
{
    public class JourneyPlanningPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public JourneyPlanningPage(IWebDriver driver) 
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        IWebElement destfrom => driver.FindElement(By.Id("InputFrom"));
        IWebElement suggestion => driver.FindElement(By.Id("stop-points-search-suggestion-0"));
        IWebElement destTo => driver.FindElement(By.Id("InputTo"));
        IWebElement destSuggestion => driver.FindElement(By.Id("stop-points-search-suggestion-0"));
        IWebElement planbutton => driver.FindElement(By.XPath("//input[@id='plan-journey-button']"));
        IWebElement cyclingResult => driver.FindElement(By.XPath("//a[@class='journey-box cycling']//div[@class='col2 journey-info']"));
        IWebElement walkingResult => driver.FindElement(By.XPath("//a[@class='journey-box walking']//div[@class='col2 journey-info']"));

        IWebElement editPreference => driver.FindElement(By.XPath("//button[@class='toggle-options more-options']"));
        IWebElement choiceRoute => driver.FindElement(By.XPath("//label[@for='JourneyPreference_2']"));
        IWebElement updateRoute => driver.FindElement(By.XPath("//div[@id='more-journey-options']//div//input[@value='Update journey']"));
        IWebElement journeyTime => driver.FindElement(By.XPath("//div[@id='option-1-heading']//div[@class='journey-time no-map']"));
        IWebElement detailView => driver.FindElement(By.CssSelector("div[id='option-1-content'] button[class='secondary-button show-detailed-results view-hide-details']"));
        IWebElement stairs => driver.FindElement(By.XPath("//div[@class='access-information']//a[@aria-label='Up stairs']"));
        IWebElement upLift => driver.FindElement(By.XPath("//div[@class='access-information']//a[@aria-label='Up lift']"));
        IWebElement levelWalk => driver.FindElement(By.XPath("//div[@class='access-information']//a[@aria-label='Level walkway']"));

        public void EnterDesinationFrom(string dest1) 
        {
            destfrom.SendKeys("Leicester");
        }
        public void SelectDestinationFrom() 
        {
            suggestion.Click();
        }
        public void EnterDestinationTo(string dest2)
        {
            destTo.SendKeys("Covent");
        }
        public void SelectDestinationTo()
        {
            destSuggestion.Click();
        }
        public void ClickOnPlanButtom()
        {
            planbutton.Click();
        }
        public bool IsCyclingOptionDisplay()
        {
            return cyclingResult.Enabled;
        }
        public bool IsWalkingOptionDisplay()
        {
            return walkingResult.Enabled;   
        }

        public void SetPref()
        {
            editPreference.Click();
        }
        public void chooseRout()
        {
            choiceRoute.Click();
        }
        public void updteRout()
        {
            updateRoute.Click();
        }
        public bool IsjourneyTimDisplay()
        {
            return journeyTime.Enabled;
        }
        public void details()
        {
            detailView.Click();
        }
        public bool IsStairDisplay()
        {
            return stairs.Enabled;
        }
        public bool IsLiftDisplay()
        {
            return upLift.Enabled;
        }
        public bool IslevelWalkDisplay()
        {
            return levelWalk.Enabled;
        }


    }
    }

