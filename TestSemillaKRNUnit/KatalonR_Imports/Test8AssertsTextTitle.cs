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
    public class Test8AssertsTextTitle
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
        public void The8AssertsTextTitleTest()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/text-box");
            driver.FindElement(By.Id("userName")).Click();
            driver.FindElement(By.Id("userName")).Clear();
            driver.FindElement(By.Id("userName")).SendKeys("Alex montoya");
            driver.FindElement(By.Id("userEmail")).Click();
            driver.FindElement(By.Id("userEmail")).Clear();
            driver.FindElement(By.Id("userEmail")).SendKeys("mail@mail.not");
            driver.FindElement(By.Id("currentAddress")).Click();
            driver.FindElement(By.Id("currentAddress")).Clear();
            driver.FindElement(By.Id("currentAddress")).SendKeys("123asddqqerytuy");
            driver.FindElement(By.Id("permanentAddress")).Click();
            driver.FindElement(By.Id("permanentAddress")).Clear();
            driver.FindElement(By.Id("permanentAddress")).SendKeys("qwrewewescsdv123");
            // Warning: assertTextNotPresent may require manual changes
            Assert.IsFalse(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*id=permanentAddress[\\s\\S]*$"));
            driver.FindElement(By.Id("submit")).Click();
            Assert.AreEqual("ToolsQA", driver.Title);
            driver.Close();
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
