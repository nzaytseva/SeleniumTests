using System;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Net;
using OpenQA.Selenium.Internal;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Security.AccessControl;
using System.Text;

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

        public static FirefoxDriver PmxAuthorize(string login, string password)
        {
            InitializeDriver();
            driver.Navigate().GoToUrl(url);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(OpenQA.Selenium.By.Id("usernameField")));


            //   driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            SelectElement list = new SelectElement(driver.FindElementByCssSelector("select"));
            list.SelectByIndex(0);
            driver.FindElementById("usernameField").SendKeys(login);
            driver.FindElementById("passwordField").SendKeys(password + OpenQA.Selenium.Keys.Enter);

            return driver;
           // string currentDirectory = Directory.GetCurrentDirectory();
           // WriteCookiesToFile(Directory.GetCurrentDirectory());
        }

        public static string GetCurrentLocale()
        {
            string s = "gg";
         //   PostHttp("http://klgw-019.corepartners.local:10002/api/token", "grant_type=password&username=LOCAL%3Aadmin&password=7777777");
            return s;

            /* 
             // go to current user profile
             driver.FindElementByClassName("profile-icon").Click();

             // get locale value
             SelectElement locale = new SelectElement(driver.FindElementByTagName("select"));
             string resultValue = "";
             string sourceValue = locale.SelectedOption.GetAttribute("value");
             if (sourceValue.Equals("Русская") || sourceValue.Equals("Russian"))
                 resultValue = "ru";
             else
                if (sourceValue.Equals("Английская") || sourceValue.Equals("English"))
                 resultValue = "en";

             return resultValue;
             */
        }

        private static void PostHttp (string url, string data)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST"; // выбираем метод запроса 
            req.Accept = "text/plain, application/json, */*; ru-RU,ru;q=0.8,en-US;q=0.5,en;q=0.3"; // добавляем заголовок и его значение
           // req.CookieContainer = cookies; // прикрепляем к запросу куки
            req.Headers.Add("DNT", "1");// добавляем заголовок и его значение
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0"; 
            req.Referer = "http://klgw-019.corepartners.local:10002/client/"; // откуда мы пришли
            req.ContentType = "application/x-www-form-urlencoded"; // определяет тип документа для ответа
            using (var requestStream = req.GetRequestStream())//отправляем поток данных
            using (var sw = new StreamWriter(requestStream)) //создаём переменную, в которой будет храниться запрос
            {
                //sw.Write(data);//записываем в поток данные
            }

            using (var responseStream = req.GetResponse().GetResponseStream())//возвращаем поток данных
            using (var sr = new StreamReader(responseStream))//переменная, в которой будет храниться ответ
            {
                var result = sr.ReadToEnd(); //считывем ответ в переменную
                using (var sw = new StreamWriter("page.html", false, Encoding.GetEncoding(1251)))//false значит? что файл будет перезаписываться каждый раз, и указываем кодировку ту что была на сайте
                    sw.Write(result);//записываем
            }
        }



        /*
        public static string GetInterpretedLocale(string sourceValue)
        {
            string resultValue = "";
            if (sourceValue.Equals("Русская") || sourceValue.Equals("Russian"))
                resultValue = "ru";
            else 
                if (sourceValue.Equals("Английская") || sourceValue.Equals("English"))
                resultValue = "en";

            return resultValue;
        }
        */
        static void WriteCookiesToFile(string filePath)
        {
            DirectorySecurity directorySecurity = new DirectorySecurity();
            directorySecurity = Directory.GetAccessControl(filePath);
            //directorySecurity.
            

            //попробовать открыть имеющийся файл на запись
            FileStream fileStream = File.Create(filePath);
            StreamWriter streamWriter = new StreamWriter(fileStream);
         
            foreach (var cookie in driver.Manage().Cookies.AllCookies)
            {
                streamWriter.WriteLine(cookie.Name + ";" + cookie.Value + ";" + cookie.Domain +
                    ";" + cookie.Path + ";" + cookie.Expiry + ";" + cookie.Secure);
            }

            streamWriter.Flush();
            streamWriter.Close();
            fileStream.Close();
        }
    }
}
