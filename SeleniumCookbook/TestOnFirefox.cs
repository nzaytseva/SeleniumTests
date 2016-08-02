using System;
using System.Collections.Generic;
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

        /*  public void FindElementByXPath()
          {
          }
          */

        public void FindElementsByTagName()
        {
            string tagName = "input";
          //  IReadOnlyCollection <FirefoxWebElement> textFields = _driver.FindElements(OpenQA.Selenium.By.TagName(tagName));
           
        }

// try FindElements


// Name 
// ID - done in FindElementById()
// TagName
// Class
// LinkText
// PartialLinkText
// XPath
// CSS
[TestCleanup]
        public void CloseBrowser()
        {
            _driver.Quit();
        }
        
    }
}
