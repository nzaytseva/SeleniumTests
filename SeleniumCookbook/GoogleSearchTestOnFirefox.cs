using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;

namespace SeleniumCookbook
{
    [TestClass]
    public class GoogleSearchTestOnFirefox
    {
        FirefoxDriver _driver;
        string _url = "https://www.google.ru/";

        [TestInitialize]
        public void TestSetup()
        {
            _driver = new FirefoxDriver();
            _driver.Navigate().GoToUrl(_url);
        }

        [TestMethod]
        public void TestGoogleSearch()
        {
            FirefoxWebElement searchString = (FirefoxWebElement)_driver.FindElement(OpenQA.Selenium.By.Id("lst-ib"));

            try
            {
                searchString.SendKeys("shameless us");
                searchString.Submit();
            }
           catch (OpenQA.Selenium.NoSuchElementException noSuchElementException)
            {
                Console.Out.WriteLine("The element not found!")
            }
  
        }

        [TestCleanup]
        public void CloseBrowser()
        {
            _driver.Quit();
        }
        
    }
}
