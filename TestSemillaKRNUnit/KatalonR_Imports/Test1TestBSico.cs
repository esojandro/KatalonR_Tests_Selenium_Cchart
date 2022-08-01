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
    public class Test1TestBSico
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
        public void The1TestBSicoTest()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Elements'])[1]/preceding::*[name()='svg'][1]")).Click();
            driver.FindElement(By.Id("item-0")).Click();
            driver.FindElement(By.Id("userName")).Click();
            driver.FindElement(By.Id("userName")).Clear();
            driver.FindElement(By.Id("userName")).SendKeys("Mike");
            driver.FindElement(By.Id("userEmail")).Click();
            driver.FindElement(By.Id("userEmail")).Clear();
            driver.FindElement(By.Id("userEmail")).SendKeys("m@gmail.com");
            driver.FindElement(By.Id("currentAddress")).Click();
            driver.FindElement(By.Id("currentAddress")).Clear();
            driver.FindElement(By.Id("currentAddress")).SendKeys("Prueba valores");
            driver.FindElement(By.Id("permanentAddress")).Click();
            driver.FindElement(By.Id("permanentAddress")).Clear();
            driver.FindElement(By.Id("permanentAddress")).SendKeys("No lo se, prueba 2");
            driver.FindElement(By.Id("submit")).Click();
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
