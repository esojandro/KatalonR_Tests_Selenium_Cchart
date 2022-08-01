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
    public class Test15Datos
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
        public void The15DatosTest()
        {
            // ERROR: Caught exception [ERROR: Unsupported command [loadVars | test15_data.csv | ]]
            driver.Navigate().GoToUrl("https://katalon-demo-cura.herokuapp.com/");
            driver.FindElement(By.XPath("//a[@id='menu-toggle']/i")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("txt-username")).Click();
            driver.FindElement(By.Id("txt-username")).Clear();
            driver.FindElement(By.Id("txt-username")).SendKeys("John Doe");
            driver.FindElement(By.Id("txt-password")).Click();
            driver.FindElement(By.XPath("//section[@id='login']/div/div/div[2]/form/div[3]")).Click();
            driver.FindElement(By.Id("txt-password")).Clear();
            driver.FindElement(By.Id("txt-password")).SendKeys("ThisIsNotAPassword");
            driver.FindElement(By.XPath("//section[@id='login']/div/div/div[2]/form/div[3]/label")).Click();
            driver.FindElement(By.Id("btn-login")).Click();
            driver.FindElement(By.Id("txt_visit_date")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sa'])[1]/following::td[25]")).Click();
            driver.FindElement(By.Id("txt_comment")).Click();
            driver.FindElement(By.Id("txt_comment")).Clear();
            driver.FindElement(By.Id("txt_comment")).SendKeys("${Comment}");
            driver.FindElement(By.Id("btn-book-appointment")).Click();
            driver.FindElement(By.XPath("//a[@id='menu-toggle']/i")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
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
