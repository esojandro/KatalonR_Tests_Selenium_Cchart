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
    public class Test11SumaUsandoJsonYQuemandoLaOperaciN
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
        public void The11SumaUsandoJsonYQuemandoLaOperaciNTest()
        {
            // ERROR: Caught exception [ERROR: Unsupported command [loadVars | test11_data.json | ]]
            driver.Navigate().GoToUrl("https://testsheepnz.github.io/");
            driver.FindElement(By.XPath("//a[@id='gotoBasicCalc']/div")).Click();
            driver.FindElement(By.Id("number1Field")).Click();
            driver.FindElement(By.Id("number1Field")).Clear();
            driver.FindElement(By.Id("number1Field")).SendKeys("${n1}");
            driver.FindElement(By.Id("number2Field")).Click();
            driver.FindElement(By.Id("number2Field")).Clear();
            driver.FindElement(By.Id("number2Field")).SendKeys("${n2}");
            driver.FindElement(By.Id("selectOperationDropdown")).Click();
            new SelectElement(driver.FindElement(By.Id("selectOperationDropdown"))).SelectByText("Add");
            driver.FindElement(By.Id("calculateButton")).Click();
            driver.FindElement(By.Id("clearButton")).Click();
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
