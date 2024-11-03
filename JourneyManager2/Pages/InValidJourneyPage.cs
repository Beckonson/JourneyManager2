using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyManager2.Pages
{
    public class InValidJourneyPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public InValidJourneyPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        IWebElement destfrom => driver.FindElement(By.Id("InputFrom"));
        IWebElement destTo => driver.FindElement(By.Id("InputTo"));
        IWebElement plan => driver.FindElement(By.XPath("//input[@id='plan-journey-button']"));
        IWebElement invalidLocs => driver.FindElement(By.CssSelector("div[class='from-results disambiguation-wrapper clearfix'] div[class='info-message disambiguation'] span"));
        IWebElement errorMessge1 => driver.FindElement(By.XPath("//span[@id='InputFrom-error']"));
        IWebElement errorMessge2 => driver.FindElement(By.XPath("//span[@id='InputTo-error']"));

        public void inputFrom(string dest1)
        {
            destfrom.SendKeys("ert34u");
        }
        public void inputTo(string dest2)
        {
            destTo.SendKeys("edgsg");
        }
        public void ClickOnPlan()
        {
            plan.Click();
        }
        public bool IslocationsDisplay(string invalidLocText)
        {
            return invalidLocs.Displayed;
        }
        public bool fromErrDisplay1(string invalidLocText)
        {
            return errorMessge1.Enabled;
        }
        public bool toErrDisplay()
        {
            return errorMessge2.Enabled;

        }
    }
}
