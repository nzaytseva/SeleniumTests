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
        FirefoxWebElement _calculatorForm;

        [TestInitialize]
        public void GoToUrl()
        {
            string formId = "calc3";
            string formName = "msje_calc";

            _driver = new FirefoxDriver();
            _driver.Navigate().GoToUrl(_url);         
            _calculatorForm = (FirefoxWebElement)_driver.FindElementById(formId);
            // проверить, что это действительно нужный нам калькулятор
            Assert.AreEqual(formName, _calculatorForm.GetAttribute("name"));
        }

        [TestMethod]
        public void CalculateCaloriesToLose()
        {
            string age = "23";
            string heightValue = "175";
            string weightValue = "65";
            string activityId = "e2";          

            SelectFemaleButton();
            SpecifyAge(age);
            SpecifyHeight(heightValue);
            SpecifyWeight(weightValue);
            SelectActivityLevel(activityId);
            ClickCalculateButton();

            
            FirefoxWebElement resultField = (FirefoxWebElement)_calculatorForm.FindElementByName("result_lose");

           // DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);

            string result = resultField.GetAttribute("placeholder");
            Assert.IsNotNull(result);
            Debug.Print("The calories to lose weight are: {0}", result.ToString());
        }

      /*  FirefoxWebElement GetCalculatorForm()
        {
            string formId = "calc3";
            string formName = "msje_calc";
            FirefoxWebElement calculatorForm = (FirefoxWebElement)_driver.FindElementById(formId);
            // проверить, что это действительно нужный нам калькулятор
            Assert.AreEqual(formName, calculatorForm.GetAttribute("name"));

            return calculatorForm;
        }*/

        void SelectFemaleButton()
        {
            string buttonId = "female";
            //FirefoxWebElement calculatorForm = GetCalculatorForm();

            FirefoxWebElement femaleButton = (FirefoxWebElement)_calculatorForm.FindElementById(buttonId);
           // Assert.AreEqual("Девушка", femaleButton);
            if (!femaleButton.Selected)
                femaleButton.Click();
        }

        void SpecifyAge(string ageValue)
        {
            FirefoxWebElement ageField;
           // FirefoxWebElement calculatorForm = GetCalculatorForm();
            string fieldName = "age";

            ageField = (FirefoxWebElement)_calculatorForm.FindElementByName(fieldName);
            Assert.AreEqual("лет", ageField.GetAttribute("placeholder"));
            ageField.SendKeys(ageValue);
        }

        void SpecifyHeight(string heightValue)
        {
            FirefoxWebElement heightField;
         //   FirefoxWebElement calculatorForm = GetCalculatorForm();
            string fieldName = "cm";

            heightField = (FirefoxWebElement)_calculatorForm.FindElementByName(fieldName);
            Assert.AreEqual("Рост", heightField.GetAttribute("placeholder"));
            heightField.SendKeys(heightValue);
        }

        void SpecifyWeight(string weightValue)
        {
            FirefoxWebElement weightField;
        //    FirefoxWebElement calculatorForm = GetCalculatorForm();
            string fieldName = "kg";

            weightField = (FirefoxWebElement)_calculatorForm.FindElementByName(fieldName);
            Assert.AreEqual("Вес", weightField.GetAttribute("placeholder"));
            weightField.SendKeys(weightValue);
        }

        void SelectActivityLevel(string buttonId)
        {
            FirefoxWebElement radioButton = (FirefoxWebElement)_calculatorForm.FindElementById(buttonId);

            if (!radioButton.Selected)
                radioButton.Click();
        }

        void ClickCalculateButton()
        {
            //FirefoxWebElement calculatorForm = GetCalculatorForm();
            FirefoxWebElement calculateButton;
            string buttonId = "get_msje";

            calculateButton = (FirefoxWebElement)_calculatorForm.FindElementById(buttonId);
            calculateButton.Click();
        }
        /*   [TestCleanup]
           public void CloseBrowser()
           {
               _driver.Close();
           }*/
    }
}
