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
    public class Test4FormularioUtilizaciNXpath
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
        public void The4FormularioUtilizaciNXpathTest()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            driver.FindElement(By.CssSelector("path")).Click();
            driver.FindElement(By.Id("firstName")).Click();
            driver.FindElement(By.Id("firstName")).Clear();
            driver.FindElement(By.Id("firstName")).SendKeys("M");
            driver.FindElement(By.Id("lastName")).Click();
            driver.FindElement(By.Id("lastName")).Clear();
            driver.FindElement(By.Id("lastName")).SendKeys("R");
            driver.FindElement(By.Id("userEmail")).Click();
            driver.FindElement(By.Id("userEmail")).Clear();
            driver.FindElement(By.Id("userEmail")).SendKeys("no email fail");
            driver.FindElement(By.XPath("//div[@id='genterWrapper']/div[2]/div[3]/label")).Click();
            driver.FindElement(By.Id("userNumber")).Click();
            driver.FindElement(By.Id("userNumber")).Clear();
            driver.FindElement(By.Id("userNumber")).SendKeys("lestters");
            driver.FindElement(By.Id("dateOfBirthInput")).Click();
            driver.FindElement(By.XPath("//div[@id='dateOfBirth']/div[2]/div[2]/div/div/div[2]/div[2]/div[4]/div[5]")).Click();
            driver.FindElement(By.XPath("//div[@id='subjectsContainer']/div/div")).Click();
            driver.FindElement(By.Id("subjectsInput")).Clear();
            driver.FindElement(By.Id("subjectsInput")).SendKeys("karkarta");
            driver.FindElement(By.XPath("//div[@id='hobbiesWrapper']/div[2]/div/label")).Click();
            driver.FindElement(By.XPath("//div[@id='subjectsContainer']/div/div")).Click();
            driver.FindElement(By.Id("currentAddress")).Clear();
            driver.FindElement(By.Id("currentAddress")).SendKeys("12312312lettes***/*-+");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // Espera implicita en Selenium C# 5's
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
