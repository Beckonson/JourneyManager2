using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;

namespace JourneyManager2.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
       
        IWebDriver driver;

        [BeforeScenario("@smoke")]
        [BeforeScenario(Order = 1)]
        public void BeforeScenarioWithTag()
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

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}