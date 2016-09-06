using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;


namespace SeleniumCookbook
{
    [TestClass]
    public class PmxProjects
    {
        FirefoxDriver driver;
        string url = "http://klgw-019.corepartners.local:10022/client/#/auth/logon";

        [TestInitialize]
        public void GoToUrl()
        {
            CookieInfo.PmxAuthorize("admin", "7777777");

           /* FirefoxBinary firefoxPath = new FirefoxBinary("C:\\program files\\Mozilla Firefox\\firefox.exe");
            FirefoxProfile firefoxProfile = new FirefoxProfile();
            driver = new FirefoxDriver(firefoxPath, firefoxProfile);

            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));*/
        }

        [TestMethod]
        public void Test()
        { }

    }
}
