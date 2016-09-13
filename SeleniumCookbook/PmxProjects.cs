using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

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
            driver = CookieInfo.PmxAuthorize("admin", "7777777");
            driver.Manage().Window.Maximize();
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
        public void OpenProjects()
        {
            string projectsClassName = "project-icon";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(OpenQA.Selenium.By.ClassName(projectsClassName)));

            try
            {
                FirefoxWebElement projects = (FirefoxWebElement)driver.FindElementByClassName(projectsClassName);
                projects.Click();
            }
            catch (OpenQA.Selenium.NoSuchElementException message)
            {
                Debug.Print(message.Message);
            }
        }

    }
}
