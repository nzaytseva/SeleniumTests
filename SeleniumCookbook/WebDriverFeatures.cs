using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Drawing;
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
            string url = "http://klgw-019.corepartners.local:50102/client/#/";
            string currentWindowHandle = _driver.CurrentWindowHandle;
            
        }

    }
}
