using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace SeleniumCookbook
{
    [TestFixture]
    public class BMICalculatorNUnitTest
    {
        FirefoxDriver driver;

        [SetUp]
        public void TestSetup()
        {
            driver = new FirefoxDriver();
        }

        [TestCaseSource("BmiTestData")]
        public void TestBmiCalculator(string height, string weight, string expectedBmi, string expectedCategory)
        {
            driver.Navigate().GoToUrl("http://cookbook.seleniumacademy.com/bmicalculator.html");
            FirefoxWebElement heightElement = (FirefoxWebElement)driver.FindElementByName("heightCMS");
            heightElement.SendKeys(height);
            FirefoxWebElement weightElement = (FirefoxWebElement)driver.FindElementByName("weightKg");
            weightElement.SendKeys(weight);
            FirefoxWebElement calculateButton = (FirefoxWebElement)driver.FindElementById("Calculate");
            calculateButton.Click();

            FirefoxWebElement bmiElement = (FirefoxWebElement)driver.FindElementByName("bmi");
            Assert.AreEqual(expectedBmi, bmiElement.GetAttribute("value"));
            FirefoxWebElement bmiCatElement = (FirefoxWebElement)driver.FindElementByName("bmi_category");
            Assert.AreEqual(expectedCategory, bmiCatElement.GetAttribute("value"));
        }

        [TearDown]
        public void TestCleanUp()
        {
            driver.Quit();
        }

        /*
        private IEnumerable<string> BmiTestData
        {
            get { return GetBmiTestData(); }
        }

        private IEnumerable<string> GetBmiTestData()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("c:\\data.xml");
            return
                from vars in doc.Descendants("vars")
                let height = vars.Attribute("height").Value
                let weight = vars.Attribute("weight").Value
                let expectedBmi =
                vars.Attribute("bmi").Value
                let expectedCategory =
                vars.Attribute("bmi_category").Value
                select new object[] { height, weight, expectedBmi, expectedCategory };
            }
        }
        */
    }
}
