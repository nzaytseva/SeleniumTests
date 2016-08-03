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
            _driver = new FirefoxDriver();
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

        /*
        [TestMethod]
          public void FindElementByXPath()
          {
          }
          */

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
