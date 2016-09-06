using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using System.Diagnostics;

namespace SeleniumCookbook
{
    public class CookieInfo
    {
        static FirefoxDriver driver;

        public static void InitializeDriver()
        {
            FirefoxBinary firefoxPath = new FirefoxBinary("C:\\program files\\Mozilla Firefox\\firefox.exe");
            FirefoxProfile firefoxProfile = new FirefoxProfile();
            driver = new FirefoxDriver(firefoxPath, firefoxProfile);
        }

        public static void PmxAuthorize(string login, string password)
        {
            string url = "http://klgw-019.corepartners.local:10022/client/#/";
            InitializeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();

            driver.FindElementById("usernameField").SendKeys(login);
            driver.FindElementById("passwordField").SendKeys(password + OpenQA.Selenium.Keys.Enter);
        }
    }
}
