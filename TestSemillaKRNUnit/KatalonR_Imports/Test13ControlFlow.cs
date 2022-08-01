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
    public class Test13ControlFlow
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
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void The13ControlFlowTest()
        {
            driver.Navigate().GoToUrl("https://cms.demo.katalon.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//a[@href='?add-to-cart=54'][contains(.,'Add to cart')]")).Click();
            //driver.FindElement(By.XPath("(//a[@href='https://cms.demo.katalon.com/cart/'][contains(.,'View cart')])[1]")).Click(); Da click e ingresa al carrito
            try
            {
                Assert.AreEqual("VIEW CART", driver.FindElement(By.XPath("//a[@href='https://cms.demo.katalon.com/cart/'][contains(.,'View cart')]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.XPath("//main[@id='main']/div[2]/ul/li[2]/div/a[2]")).Click();
            try
            {
                Assert.AreEqual("VIEW CART", driver.FindElement(By.XPath("//main[@id='main']/div[2]/ul/li[2]/div/a[3]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.XPath("//main[@id='main']/div[2]/ul/li[3]/div/a[2]")).Click();
            try
            {
                Assert.AreEqual("VIEW CART", driver.FindElement(By.XPath("//main[@id='main']/div[2]/ul/li[3]/div/a[3]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.XPath("//main[@id='main']/div[2]/ul/li[4]/div/a[2]")).Click();
            try
            {
                Assert.That(driver.FindElement(By.XPath("//main[@id='main']/div[2]/ul/li[4]/div/a[3]")).Text, Is.EqualTo("VIEW CART"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.XPath("//main[@id='main']/div[2]/ul/li[7]/div/a[2]")).Click();
            try
            {
                Assert.AreEqual("VIEW CART", driver.FindElement(By.XPath("//main[@id='main']/div[2]/ul/li[7]/div/a[3]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
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
