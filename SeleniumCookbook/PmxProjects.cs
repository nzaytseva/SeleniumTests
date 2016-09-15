using System;
using System.Collections.Generic;
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
            locale = CookieInfo.GetCurrentLocale();
            driver.Manage().Window.Maximize(); 
            Debug.Print(locale);
        }

    [TestMethod]
        public void CreateProject()
        {
            OpenProjects();
            OpenPojectCreationPage();
          //  FillRequiredProjectFieldsCorrectly();
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
                // сделать проверку названия кнопок в зависимости от текущей локали
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

        void FillRequiredProjectFieldsCorrectly()
        {
            // fill "Name" field
            driver.FindElementByName("nameField").SendKeys(GenerateProjectName());

            // specify project manager
            SelectElement projectManager = new SelectElement(driver.FindElementById("leadIdField"));
            Assert.AreEqual(false, projectManager.IsMultiple);
            projectManager.SelectByValue(GetProjectManagerId());

            // specify start date = current date
            driver.FindElementById("startDateField").Click();

            // press "Save" button
           // driver.FindElementByTagName("button");
        }

        string GenerateProjectName()
        {
            Random randomNumber = new Random();
            return "project " + randomNumber.Next().ToString();
        }

        string GetProjectManagerId()
        {
            return "1";
        }

        void SaveProject()
        { }
    }
}
