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
        //string url = "http://klgw-019.corepartners.local:10022/client/#/auth/logon";
        string locale;

        [TestInitialize]
        public void GoToUrl()
        {
            driver = CookieInfo.PmxAuthorize("admin", "7777777");
            driver.Manage().Window.Maximize();

            //string script = "return $('.locale')";
            //locale = driver.ExecuteAsyncScript(script, "http://klgw-019.corepartners.local:10022/client/#/").ToString();
            //Debug.Print(locale);


        }


        [TestMethod]
        public void CreateProject()
        {
            OpenProjects();
            OpenPojectCreationPage();
          //  FillProjectFieldsCorrectly();
           // SaveProject();
        }

        void OpenProjects()
        {
            string projectsClassName = "project-icon";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(OpenQA.Selenium.By.ClassName(projectsClassName)));

            try
            {
                FirefoxWebElement projects = (FirefoxWebElement)driver.FindElementByClassName(projectsClassName);
                //if()
                //Assert.AreEqual("Projects", projects);
                //else
                //    Assert.AreEqual("Проекты", projects);
                projects.Click();
            }
            catch (OpenQA.Selenium.NoSuchElementException message)
            {
                Debug.Print(message.Message);
            }
        }

        void OpenPojectCreationPage()
        {
            string buttonNewId = "pageHeaderActionsDropdown";
            driver.FindElementById(buttonNewId).Click();

            string buttonNewProjectCssSelector = "a[href='#/projects/create']";
           // Assert.AreEqual("+ New Project", projects);
            driver.FindElementByCssSelector(buttonNewProjectCssSelector).Click();

        }

        void FillProjectFieldsCorrectly()
        { }

        void SaveProject()
        { }
    }
}
