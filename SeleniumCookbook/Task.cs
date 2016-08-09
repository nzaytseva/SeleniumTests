using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumCookbook
{
    class Task
    {
        FirefoxDriver _driver;
        string _url = "https://rasp.yandex.ru/";

        [TestInitialize]
        public void GoToUrl()
        {
            _driver = new FirefoxDriver();
            _driver.Navigate().GoToUrl(_url);
        }

        FirefoxWebElement FindDepartureField()
        {
            string fieldName = "fromName";
            return (FirefoxWebElement)_driver.FindElementByName(fieldName);   
        }

        [TestMethod]
        public void FindSchedule()
        {
            try
            {
                FindDepartureField();
            }
            catch (OpenQA.Selenium.NoSuchElementException exception)
            {
                Debug.Print(exception.Message);
            }
        }

        /*
        [TestCleanup]
        public void CloseBrowser()
        {
            _driver.Quit();
        }
        */
    }
}
