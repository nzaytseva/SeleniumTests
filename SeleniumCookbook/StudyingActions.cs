﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using System.IO;

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
            FirefoxBinary firefoxBinary = new FirefoxBinary("C:\\program files\\Mozilla Firefox\\firefox.exe");
            FirefoxProfile firefoxProfile = new FirefoxProfile();
            _driver = new FirefoxDriver(firefoxBinary, firefoxProfile);
            //  _driver = new FirefoxDriver(new FirefoxBinary(), new FirefoxProfile(), TimeSpan.FromSeconds(180));
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
            int x = 0, y = 0;
            FirefoxWebElement searchString = (FirefoxWebElement)_driver.FindElementById(searchStringId);
            Assert.AreEqual(searchString.GetAttribute("name"), searchStringName);

            Actions builder = new Actions(_driver);
            x = searchString.Location.X + 1;
            y = searchString.Location.Y + 1;

            builder.MoveByOffset(x, y).Click();
            builder.Perform();
            Debug.Print("x: {0}, y: {1}", x, y);
            //  searchString.SendKeys(OpenQA.Selenium.Keys.Shift + text + OpenQA.Selenium.Keys.Enter);
        }

        public void MoveMousePointer(int x, int y)
        {

        }
    }
}