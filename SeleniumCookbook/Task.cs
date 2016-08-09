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
    [TestClass]
    public class Task
    {
        FirefoxDriver _driver;
        string _url = "https://rasp.yandex.ru/";

        [TestInitialize]
        public void GoToUrl()
        {
            _driver = new FirefoxDriver();
            _driver.Navigate().GoToUrl(_url);
        }

        FirefoxWebElement GetDepartureField()
        {
            string fieldName = "fromName";
            return (FirefoxWebElement)_driver.FindElementByName(fieldName);   
        }

        FirefoxWebElement GetArrivalField()
        {
            string fieldName = "toName";
            return (FirefoxWebElement)_driver.FindElementByName(fieldName);
        }

        FirefoxWebElement GetDateField()
        {
            string fieldName = "when";
            return (FirefoxWebElement)_driver.FindElementByName(fieldName);
        }

        FirefoxWebElement GetSearchButton()
        {
            string buttonClassName = "y-button_islet-rasp-search";
            return (FirefoxWebElement)_driver.FindElementByClassName(buttonClassName);
        }

        FirefoxWebElement GetTomorrowButton()
        {
            //string cssSelector = "button[textContent='завтра']";
            //return (FirefoxWebElement)_driver.FindElementByCssSelector(cssSelector);

            string xPath = "//button[contains(text(),'завтра')]";
            return (FirefoxWebElement)_driver.FindElementByXPath(xPath);
        }

        FirefoxWebElement GetSuburbanLabel()
        {
            string value = "input[value='suburban'][type='radio']";
            return (FirefoxWebElement)_driver.FindElementByCssSelector(value);
        }

        [TestMethod]
        public void FindSchedule()
        {
            string requestedDeparture = "Калуга";
            string requestedArrival = "Москва";
            //string requestedDate = "13.08.2016";
            try
            {
                FirefoxWebElement departureField = GetDepartureField();
                departureField.Clear();
                departureField.SendKeys(requestedDeparture);

                FirefoxWebElement arrivalField = GetArrivalField();
                arrivalField.Clear();
                arrivalField.SendKeys(requestedArrival);

                /*
                FirefoxWebElement dateField = GetDateField();
                dateField.Clear();
                dateField.SendKeys(requestedDate);
                */

                FirefoxWebElement suburbanLabel = GetSuburbanLabel();
                suburbanLabel.Click();

                FirefoxWebElement tomorrowButton = GetTomorrowButton();
                tomorrowButton.Click();

                FirefoxWebElement searchButton = GetSearchButton();
                searchButton.Click();
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
