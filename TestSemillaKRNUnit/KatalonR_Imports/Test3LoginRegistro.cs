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
    public class Test3LoginRegistro
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
        public void The3LoginRegistroTest()
        {
            driver.Navigate().GoToUrl("http://opencart.abstracta.us/index.php?route=common/home");
            driver.FindElement(By.LinkText("My Account")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            driver.Navigate().GoToUrl("https://opencart.abstracta.us/index.php?route=account/login");
            driver.FindElement(By.Id("input-email")).Click();
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("mail@email.com");
            driver.FindElement(By.Id("input-password")).Click();
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("pass123");
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span[2]")).Click();
            driver.FindElement(By.LinkText("Register")).Click();
            driver.Navigate().GoToUrl("https://opencart.abstracta.us/index.php?route=account/register");
            driver.FindElement(By.Id("input-firstname")).Click();
            driver.FindElement(By.Id("input-firstname")).Clear();
            driver.FindElement(By.Id("input-firstname")).SendKeys("Brand");
            driver.FindElement(By.Id("input-lastname")).Click();
            driver.FindElement(By.Id("input-lastname")).Clear();
            driver.FindElement(By.Id("input-lastname")).SendKeys("Dovarn");
            driver.FindElement(By.Id("input-email")).Click();
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("mail@email.com");
            driver.FindElement(By.Id("input-telephone")).Click();
            driver.FindElement(By.Id("input-telephone")).Clear();
            driver.FindElement(By.Id("input-telephone")).SendKeys("96857423");
            driver.FindElement(By.Id("input-password")).Click();
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("pas123");
            driver.FindElement(By.Id("input-confirm")).Click();
            driver.FindElement(By.Id("input-confirm")).Clear();
            driver.FindElement(By.Id("input-confirm")).SendKeys("pas123");
            driver.FindElement(By.Name("newsletter")).Click();
            driver.FindElement(By.Name("agree")).Click();
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            driver.Navigate().GoToUrl("http://opencart.abstracta.us/index.php?route=account/success");
            driver.FindElement(By.LinkText("Continue")).Click();
            driver.Navigate().GoToUrl("https://opencart.abstracta.us/index.php?route=account/account");
            driver.FindElement(By.LinkText("My Account")).Click();
            /*
            driver.FindElement(By.LinkText("Logout")).Click();
            driver.Navigate().GoToUrl("https://opencart.abstracta.us/index.php?route=account/logout");
            driver.FindElement(By.LinkText("Continue")).Click();
            driver.Navigate().GoToUrl("http://opencart.abstracta.us/index.php?route=common/home");
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            driver.Navigate().GoToUrl("https://opencart.abstracta.us/index.php?route=account/login");
            driver.FindElement(By.Id("input-email")).Click();
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("mail@email.com");
            driver.FindElement(By.Id("input-password")).Click();
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("pas123");
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            driver.Navigate().GoToUrl("https://opencart.abstracta.us/index.php?route=account/account");
            driver.FindElement(By.LinkText("Monitors (2)")).Click();
            driver.Navigate().GoToUrl("http://opencart.abstracta.us/index.php?route=product/category&path=25_28");
            driver.FindElement(By.XPath("//div[@id='content']/div[3]/div/div/div[2]/div[2]/button/span")).Click();
            driver.Navigate().GoToUrl("http://opencart.abstracta.us/index.php?route=product/product&product_id=42");
            driver.FindElement(By.XPath("//div[@id='content']/div/div[2]/div/button/i")).Click();
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[4]/a/span")).Click();
            driver.Navigate().GoToUrl("http://opencart.abstracta.us/index.php?route=checkout/cart");
            driver.Navigate().GoToUrl("http://opencart.abstracta.us/index.php?route=checkout/cart");
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]")).Click();
            driver.FindElement(By.LinkText("My Account")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
            driver.Navigate().GoToUrl("https://opencart.abstracta.us/index.php?route=account/logout");
            driver.FindElement(By.LinkText("Continue")).Click();
            driver.Navigate().GoToUrl("http://opencart.abstracta.us/index.php?route=common/home");
            */
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
