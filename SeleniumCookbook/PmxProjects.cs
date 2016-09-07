using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Events;


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

           // EventFiringWebDriver firingDriver = new EventFiringWebDriver(driver);
           // firingDriver.ElementValueChanging += new EventHandler<WebElementEventArgs>(firingDriver_BeforeSendKeys);

        }

        /*
        void firingDriver_BeforeSendKeys(object sender, WebDriverExceptionEventArgs e)
        {
            e.Driver.
            // do action required to handle what happens after clicking button you have mentioned.
        }
        */

        [TestMethod]
        public void Test()
        { }

    }
}
