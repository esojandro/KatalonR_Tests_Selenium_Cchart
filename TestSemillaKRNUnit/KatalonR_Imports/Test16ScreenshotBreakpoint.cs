using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestSemillaKRNUnit.KatalonR_Imports
{
    [TestFixture]
    public class Test16ScreenshotBreakpoint
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            //Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void The16ScreenshotBreakpointTest()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            driver.FindElement(By.Id("txtUsername")).Click();
            driver.FindElement(By.Id("txtUsername")).Clear();
            driver.FindElement(By.Id("txtUsername")).SendKeys("admin");
            driver.FindElement(By.Id("txtPassword")).Click();
            driver.FindElement(By.Id("txtPassword")).Clear();
            driver.FindElement(By.Id("txtPassword")).SendKeys("admin123");
            driver.FindElement(By.Id("btnLogin")).Click();
            Screenshot screenshot = (driver as ITakesScreenshot).GetScreenshot();
            screenshot.SaveAsFile("Selenium_test_16_0.png", ScreenshotImageFormat.Png);
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/index.php/dashboard");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.Id("welcome")).Click();
            //driver.FindElement(By.LinkText("Logout")).Click();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/index.php/auth/login");
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
