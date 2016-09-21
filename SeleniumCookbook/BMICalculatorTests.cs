using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Data;

namespace SeleniumCookbook
{
    [TestClass]
    public class BMICalculatorTests
    {
        FirefoxDriver driver;
        private TestContext testContextInstance;

        [TestInitialize]
        public void TestSetup()
        {
            driver = new FirefoxDriver();
        }

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        [DeploymentItem("Data.xls")]
        [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data.xls;Persist Security Info = False;Extended Properties = 'Excel 12.0;HDR=Yes'", "Data$", DataAccessMethod.Sequential)]

        public void TestBMICalculator()
        {
            driver.Navigate().GoToUrl("http://dl.dropbox.com/u/55228056/bmicalculator.html");
            FirefoxWebElement height = (FirefoxWebElement)driver.FindElementByName("heightCMS");
            height.SendKeys(TestContext.DataRow["Height"].ToString());

            FirefoxWebElement weight = (FirefoxWebElement)driver.FindElementByName("weightKg");
            weight.SendKeys(TestContext.DataRow["Weight"].ToString());

            FirefoxWebElement calculateButton = (FirefoxWebElement)driver.FindElementById("Calculate");
            calculateButton.Click();

            FirefoxWebElement bmi = (FirefoxWebElement)driver.FindElementByName("bmi");
            Assert.AreEqual(TestContext.DataRow["Bmi"].ToString(), bmi.GetAttribute("value"));

            FirefoxWebElement bmiCategory = (FirefoxWebElement)driver.FindElementByName("bmi_category");
            Assert.AreEqual(TestContext.DataRow["Category"].ToString(), bmiCategory.GetAttribute("value"));
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            driver.Quit();
        }
    }
}