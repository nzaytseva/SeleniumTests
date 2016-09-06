﻿using System;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Internal;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace SeleniumCookbook
{
    public static class CookieInfo
    {
        static FirefoxDriver driver;
        static string url = "http://klgw-019.corepartners.local:10022/client/#/auth/logon";

        static void InitializeDriver()
        {
            FirefoxBinary firefoxPath = new FirefoxBinary("C:\\program files\\Mozilla Firefox\\firefox.exe");
            FirefoxProfile firefoxProfile = new FirefoxProfile();
            driver = new FirefoxDriver(firefoxPath, firefoxProfile);
        }

        public static void PmxAuthorize(string login, string password)
        {
            InitializeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            SelectElement list = new SelectElement(driver.FindElementByCssSelector("select"));
            list.SelectByIndex(0);
            driver.FindElementById("usernameField").SendKeys(login);
            driver.FindElementById("passwordField").SendKeys(password + OpenQA.Selenium.Keys.Enter);
        }

        static void WriteCookiesToFile(string filePath)
        {
            FileInfo fileWriter = new FileInfo(filePath);
            fileWriter.Create();
           // StreamWriter fileWriter = new StreamWriter(File.Create(filePath));

          //  if (fileWriter.)
           // {
                foreach (var cookie in driver.Manage().Cookies.AllCookies)
                {
                    //fileWriter.

                }
                //fileWriter
            }

        }
    }
}