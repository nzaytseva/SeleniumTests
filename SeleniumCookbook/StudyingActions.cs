using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace SeleniumCookbook
{
    [TestClass]
    public class StudyingActions
    {
        FirefoxDriver _driver;
        string _url = "http://www.zozhnik.ru/";

        [TestInitialize]
        public void GoToUrl()
        {
            _driver = new FirefoxDriver();
            _driver.Navigate().GoToUrl(_url);
        }

       /* [TestMethod]
        public void SelectSeveralElements()
        {
            Actions builder = new Actions(_driver);
            builder.KeyDown(OpenQA.Selenium.Keys.Control)
                .Click()
                .Click()
                .Click()
                .KeyUp(OpenQA.Selenium.Keys.Control);

            // Generate the composite action.
            builder.Perform();
        }
        */
        [TestMethod]
        public void PrintTextInUpperCase()
        {
            string text = "кбжу";
            string searchStringId = "s";
            string searchStringName = "s";

            FirefoxWebElement searchString = (FirefoxWebElement)_driver.FindElementById(searchStringId);
            Assert.AreEqual(searchString.GetAttribute("name"), searchStringName);

            searchString.SendKeys(OpenQA.Selenium.Keys.Shift + text + OpenQA.Selenium.Keys.Enter);
        }

           
        
    }
}
