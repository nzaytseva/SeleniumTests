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
       

        [TestInitialize]
        public void GoToUrl()
        {
            CookieInfo.PmxAuthorize("admin", "7777777");


        }

        [TestMethod]
        public void Test()
        { }

    }
}
