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
    public class Test6AssertsValue
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
        public void The6AssertsValueTest()
        {
            driver.Navigate().GoToUrl("https://testsheepnz.github.io/BasicCalculator.html");
            driver.FindElement(By.Id("number1Field")).Click();
            driver.FindElement(By.Id("number1Field")).Clear();
            driver.FindElement(By.Id("number1Field")).SendKeys("5");
            Assert.AreEqual("5", driver.FindElement(By.Id("number1Field")).GetAttribute("value"));
            driver.FindElement(By.Id("number2Field")).Click();
            driver.FindElement(By.Id("number2Field")).Clear();
            driver.FindElement(By.Id("number2Field")).SendKeys("15");
            Assert.AreEqual("15", driver.FindElement(By.Id("number2Field")).GetAttribute("value"));
            driver.FindElement(By.Id("selectOperationDropdown")).Click();
            driver.FindElement(By.Id("integerSelect")).Click();
            driver.FindElement(By.Id("calculateButton")).Click();
            driver.FindElement(By.Id("clearButton")).Click();
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
