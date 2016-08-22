using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SeleniumCookbook
{
    [TestClass]
    public class AutomatingRadioButtons
    {
        FirefoxDriver _driver;
        string _url = "http://www.zozhnik.ru/calculators/";

        [TestInitialize]
        public void GoToUrl()
        {
            _driver = new FirefoxDriver();
            _driver.Navigate().GoToUrl(_url);
        }

        [TestMethod]
        public void CalculateCalories()
        {
            string age = "23";
            string heightValue = "175";
            string weightValue = "65";

            SelectFemaleButton();
            SpecifyAge(age);
            SpecifyHeight(heightValue);
            SpecifyWeight(weightValue);
        }

        FirefoxWebElement GetCalculatorForm()
        {
            string formId = "calc3";
            string formName = "msje_calc";
            FirefoxWebElement calculatorForm = (FirefoxWebElement)_driver.FindElementById(formId);
            // проверить, что это действительно нужный нам калькулятор
            Assert.AreEqual(formName, calculatorForm.GetAttribute("name"));

            return calculatorForm;
        }

        void SelectFemaleButton()
        {
            string buttonId = "female";
            FirefoxWebElement calculatorForm = GetCalculatorForm();

            FirefoxWebElement femaleButton = (FirefoxWebElement)calculatorForm.FindElementById(buttonId);
           // Assert.AreEqual("Девушка", femaleButton);
            if (!femaleButton.Selected)
                femaleButton.Click();
        }

        void SpecifyAge(string ageValue)
        {
            FirefoxWebElement ageField;
            FirefoxWebElement calculatorForm = GetCalculatorForm();
            string fieldName = "age";

            ageField = (FirefoxWebElement)calculatorForm.FindElementByName(fieldName);
            Assert.AreEqual("лет", ageField.GetAttribute("placeholder"));
            ageField.SendKeys(ageValue);
        }

        void SpecifyHeight(string heightValue)
        {
            FirefoxWebElement heightField;
            FirefoxWebElement calculatorForm = GetCalculatorForm();
            string fieldName = "cm";

            heightField = (FirefoxWebElement)calculatorForm.FindElementByName(fieldName);
            Assert.AreEqual("Рост", heightField.GetAttribute("placeholder"));
            heightField.SendKeys(heightValue);
        }

        void SpecifyWeight(string weightValue)
        {
            FirefoxWebElement weightField;
            FirefoxWebElement calculatorForm = GetCalculatorForm();
            string fieldName = "kg";

            weightField = (FirefoxWebElement)calculatorForm.FindElementByName(fieldName);
            Assert.AreEqual("Вес", weightField.GetAttribute("placeholder"));
            weightField.SendKeys(weightValue);
        }

        /*   [TestCleanup]
           public void CloseBrowser()
           {
               _driver.Close();
           }*/
    }
}
