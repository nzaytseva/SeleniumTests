using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support;

namespace SeleniumCookbook
{
    [TestClass]
    public class GoogleSearchTestOnIE
    {
        InternetExplorerDriver driver;
        string url = "vhs-test1.corepartners.ru/client/#";
        
        [TestInitialize]
        public void TestSetup()
        {
            driver = new InternetExplorerDriver();
            driver.Navigate().GoToUrl(url);
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }

      /*  [TestMethod]
        public void ViewCourse()
        {
            //InternetExplorerWebElement webElement = driver.FindElement(by.name();
            driver.FindElement(OpenQA.Selenium.By.PartialLinkText("test")).Click();
        }
        */
    }
}
