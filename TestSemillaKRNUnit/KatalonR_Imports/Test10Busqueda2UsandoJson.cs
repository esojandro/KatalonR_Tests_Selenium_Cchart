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
    public class Test10Busqueda2UsandoJson
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
        public void The10Busqueda2UsandoJsonTest()
        {
            // ERROR: Caught exception [ERROR: Unsupported command [loadVars | test10_data.json | ]]
            driver.Navigate().GoToUrl("https://www.timeanddate.com/");
            driver.FindElement(By.XPath("//div[@id='main-content']/div[2]/div[2]/div/div/div/div[2]/div/form/input")).Click();
            driver.FindElement(By.XPath("//div[@id='main-content']/div[2]/div[2]/div/div/div/div[2]/div/form/input")).Clear();
            driver.FindElement(By.XPath("//div[@id='main-content']/div[2]/div[2]/div/div/div/div[2]/div/form/input")).SendKeys("${city}");
            driver.FindElement(By.XPath("//div[@id='main-content']/div[2]/div[2]/div/div/div/div[2]/div/form/button/i")).Click();
            driver.FindElement(By.LinkText("Home")).Click();
            driver.FindElement(By.XPath("//div[@id='main-content']/div[2]/div[2]/div[2]/div[2]/div[2]/form/input")).Click();
            driver.FindElement(By.XPath("//div[@id='main-content']/div[2]/div[2]/div[2]/div[2]/div[2]/form/input")).Clear();
            driver.FindElement(By.XPath("//div[@id='main-content']/div[2]/div[2]/div[2]/div[2]/div[2]/form/input")).SendKeys("costa");
            //driver.FindElement(By.XPath("//div[@id='po1']/div/ul/li[3]/a/span")).Click();
            //driver.FindElement(By.LinkText("Home")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [endLoadVars |  | ]]
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
