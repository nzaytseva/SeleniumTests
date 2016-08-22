using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Diagnostics;

namespace SeleniumCookbook
{
    [TestClass]
    public class AutomatingLists
    {
        string _url = "http://kalugahouse.ru/catalog/appartments/prodazha/";
        FirefoxDriver _driver;
        SelectElement _dropdown;

        [TestInitialize]
        public void GoToUrl()
        {
            _driver = new FirefoxDriver();
            _driver.Navigate().GoToUrl(_url);
        }

        [TestMethod]
        public void CheckIsMultipleList()
        {
            string dropdownName = "etag";
            
            _dropdown = new SelectElement(_driver.FindElementByName(dropdownName));   
            // недопустим множественный выбор
            Assert.IsFalse(_dropdown.IsMultiple);
        }

        [TestMethod]
        public void CheckElementsCount()
        {
            string dropdownName = "etag";
            int elementsAmoung = 5;

            _dropdown = new SelectElement(_driver.FindElementByName(dropdownName));
            // недопустим множественный выбор
            Assert.IsFalse(_dropdown.IsMultiple);
            // 5 элементов в списке 
            Assert.AreEqual(elementsAmoung, _dropdown.Options.Count);
        }

        List<string> FillListWithExpectedResults()
        {
            List<string> list = new List<string>();
            list.Add("любой");
            list.Add("не первый");
            list.Add("не последний");
            list.Add("не первый и не последний");
            list.Add("только первый");
            return list;
        }

        [TestMethod]
        public void CheckListContent()
        {
            string dropdownName = "etag";
            List<string> expectedValues = new List<string>(FillListWithExpectedResults());
            List<string> actualValues = new List<string>();

            _dropdown = new SelectElement(_driver.FindElementByName(dropdownName));

            Debug.Print("Actual values:");
            foreach (FirefoxWebElement option in _dropdown.Options)
            {
                actualValues.Add(option.Text);
                Debug.Print("{0}", option.Text);
            }

            // совпадают ли фактические элементы с ожидаемыми
            CollectionAssert.AreEqual(actualValues, expectedValues);
        }

        [TestCleanup]
        public void CloseBrowser()
        {
            _driver.Close();
        }
    }
}
