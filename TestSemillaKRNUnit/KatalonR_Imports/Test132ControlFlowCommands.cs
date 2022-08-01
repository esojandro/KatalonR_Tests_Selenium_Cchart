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
    public class Test132ControlFlowCommands
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
        public void The132ControlFlowCommandsTest()
        {
            driver.Navigate().GoToUrl("https://cms.demo.katalon.com/");
            string index = "1";
            // ERROR: Caught exception [ERROR: Unsupported command [while | ${index} < 13 | ]]
            string itemText = driver.FindElement(By.XPath("//main[@id='main']/div[2]/ul/li[" + index + "]/div/a[2]")).Text;
            // ERROR: Caught exception [ERROR: Unsupported command [if | "${itemText}" == "Add to cart" | ]]
            driver.FindElement(By.XPath("//main[@id='main']/div[2]/ul/li[2]/div/a[2]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            try
            {
                Assert.AreEqual("VIEW CART", driver.FindElement(By.XPath("//main[@id='main']/div[2]/ul/li[2]/div/a[3]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [endIf |  | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [getEval | ${index} + 1 | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [endWhile |  | ]]
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
