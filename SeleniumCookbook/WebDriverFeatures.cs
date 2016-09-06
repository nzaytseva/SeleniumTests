using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Diagnostics;
using OpenQA.Selenium.Interactions;

namespace SeleniumCookbook
{
    [TestClass]
    public class WebDriverFeatures
    {
        FirefoxDriver _driver;
        string _url = "https://www.yandex.ru/";

        [TestInitialize]
        public void GoToUrl()
        {
            //OpenQA.Selenium.ICapabilities firefoxCapabilities;                
            FirefoxBinary path = new FirefoxBinary("C:\\Program Files\\Mozilla Firefox\\firefox.exe");
            FirefoxProfile firefoxProfile = new FirefoxProfile();
            _driver = new FirefoxDriver(path, firefoxProfile);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(_url);
        }

        [TestMethod]
        public void MakeScreenshot()
        {
            string screenshotName = "C:\\Users\\nzaytseva\\Desktop\\screen.jpg";

            OpenQA.Selenium.Screenshot screenshot = _driver.GetScreenshot();
            screenshot.SaveAsFile(screenshotName, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        [TestMethod]
        public void SwitchAmongWindows()
        {
            string searchStringId = "text";
            string request = "газета онлайн";
            string firstWindowHandle = _driver.CurrentWindowHandle;
            FirefoxWebElement searchString = (FirefoxWebElement)_driver.FindElementById(searchStringId);
            searchString.SendKeys(request + OpenQA.Selenium.Keys.Enter);

            string linkText = "газета";
            FirefoxWebElement link = (FirefoxWebElement)_driver.FindElementByPartialLinkText(linkText);
            link.Click();

            Debug.Print("{0} windows opened", _driver.WindowHandles.Count);

            // Open the first window
            _driver.SwitchTo().Window(firstWindowHandle);
        }

        [TestMethod]
        public void SwitchAmongFrames()
        {
            /*
            Actions builder = new Actions(_driver);
            builder
                .KeyDown(OpenQA.Selenium.Keys.Control)
                .SendKeys(ConsoleKey.N.ToString())
                .KeyUp(OpenQA.Selenium.Keys.Control)
                .Perform();
            */

            string searchStringId = "text";
            string request = "газета онлайн";
            string firstWindowHandle = _driver.CurrentWindowHandle;
            FirefoxWebElement searchString = (FirefoxWebElement)_driver.FindElementById(searchStringId);
            searchString.SendKeys(request + OpenQA.Selenium.Keys.Enter);

            string linkText = "газета";
            FirefoxWebElement link = (FirefoxWebElement)_driver.FindElementByPartialLinkText(linkText);
            link.Click();

            Debug.Print("{0} windows opened", _driver.WindowHandles.Count);

            // Open the first window
            _driver.SwitchTo().Window(firstWindowHandle);
        }
    }
}
