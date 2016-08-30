using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using System.Diagnostics;

namespace SeleniumCookbook
{
    [TestClass]
    public class TestOnFirefox
    {
        FirefoxDriver _driver;
        string _url = "https://rasp.yandex.ru/";

        [TestInitialize]
        public void TestSetup()
        {
            FirefoxBinary firefoxBinary = new FirefoxBinary("C:\\program files\\Mozilla Firefox\\firefox.exe");
            FirefoxProfile firefoxProfile = new FirefoxProfile();
            _driver = new FirefoxDriver(firefoxBinary, firefoxProfile);
            //_driver = new FirefoxDriver();
            _driver.Navigate().GoToUrl(_url);
        }

        [TestMethod]
        public void FindElementById()
        {
            string id = "uniqs383270";
            //FindElement the date field by id           
            try
            {
                FirefoxWebElement whenDate = (FirefoxWebElement)_driver.FindElement(OpenQA.Selenium.By.Id(id));
                whenDate.Click();
            }
            catch (OpenQA.Selenium.NoSuchElementException noSuchElementException)
            {
                Debug.Print("The element with id {0} not found!", id);
            }
        }

        [TestMethod]
        public void FindChangeCityButtonByXPath()
        {
            // xPath of "change city" button
            //   string xPath = "html/body/main/div[1]/h2/button";
            // xPath of "find station" field
            string xPath = "//input[@name='query autocomplete']";

            try
            {
                FirefoxWebElement changeCityButton = (FirefoxWebElement)_driver.FindElementByXPath(xPath);
                changeCityButton.Click();
                //  FindNewCity();
                // получить атрибут form кнопки 
            }
            catch (OpenQA.Selenium.NoSuchElementException noSuchElementException)
            {
                Debug.Print("The element on xPath {0} not found!", xPath);
            }
        }

        [TestMethod]
        public void FindDepartureByCssSelector()
        {
            string cssSelector = "html/body/div[1]/header/div[3]/div[2]/form/div[1]/div/span/input[1]";
            string departureName = "Калуга";
            try
            {
                FirefoxWebElement departure = (FirefoxWebElement)_driver.FindElementByCssSelector(cssSelector);
                departure.SendKeys(departureName);
            }
            catch (OpenQA.Selenium.NoSuchElementException noSuchElementException)
            {
                Debug.Print("The element on cssSelector {0} not found!", cssSelector);
            }
        }
            

        [TestMethod]
        public void FindStationFieldByXPath()
        {
            // xPath of "find station" field
            string xPath = "//input[@name='query']";

            try
            {
                FirefoxWebElement findStationField = (FirefoxWebElement)_driver.FindElementByXPath(xPath);
                findStationField.SendKeys("кокошкино");
            }
            catch (OpenQA.Selenium.NoSuchElementException noSuchElementException)
            {
                Debug.Print("The element on xPath {0} not found!", xPath);
            }
        }

        /*  [TestMethod]
          public void FindNewCity()
          {
              // xPath request field
              string xPath = "html/body/main/div[1]/h2/button";
              string request = "Калуга";

              try
              {
                  FirefoxWebElement requestField = (FirefoxWebElement)_driver.FindElementByXPath(xPath);
                  requestField.SendKeys(request);

              }
              catch (OpenQA.Selenium.NoSuchElementException noSuchElementException)
              {
                  Debug.Print("The element on xPath {0} not found!", xPath);
              }
          }*/

        [TestMethod]
        public void FindElementsByTagName()
        {
            string tagName = "button";
            // Find all input elements
            IReadOnlyCollection <OpenQA.Selenium.IWebElement> buttons = _driver.FindElements(OpenQA.Selenium.By.TagName(tagName));
            Debug.Print("There were {0} elements found", buttons.Count);
        }

        [TestMethod]
        public void FindElemetByClassName()
        {
            string swapButtonClassName = "y-button_islet-rasp-swap";
            string destinationFieldName = "toName";
            FirefoxWebElement swapButton;
            FirefoxWebElement destinationTextField;

            // find and fill "destination" text field
            try
            {
                destinationTextField = (FirefoxWebElement)_driver.FindElementByName(destinationFieldName);
                destinationTextField.SendKeys("Калуга");
            }
            catch (OpenQA.Selenium.NoSuchElementException noSuchElementException)
            {
                Debug.Print("The element {0} not found", destinationFieldName);
            }

            // find and click "swap cities" button
            try
            {
                swapButton = (FirefoxWebElement)_driver.FindElementByClassName(swapButtonClassName);
                swapButton.Click();
            }
            catch (OpenQA.Selenium.NoSuchElementException noSuchElementException)
            {
                Debug.Print("The element of the class {0} not found", swapButtonClassName);
            }
        }

        [TestMethod]
        public void FindElementByLinkText()
        {
            string linkText = "Лискинское";
            FirefoxWebElement link;

            // find and click the link "Вяземское"
            try
            {
                link = (FirefoxWebElement)_driver.FindElementByLinkText(linkText);
                link.Click();
            }
            catch (OpenQA.Selenium.NoSuchElementException noSuchElementException)
            {
                Debug.Print("The link with the text {0} not found", linkText);
            }
        }

        // Name - done in FindElemetByClassName()
        // ID - done in FindElementById()
        // TagName - done in FindElementsByTagName()
        // Class - done in FindElemetByClassName()
        // LinkText - done in FindElementByLinkText()
        // PartialLinkText - won't be done
        // XPath
        // CSS

        /*  [TestCleanup]
          public void CloseBrowser()
          {
              _driver.Quit();
          }
          */
    }
}
