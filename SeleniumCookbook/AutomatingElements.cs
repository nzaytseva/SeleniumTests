using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;


namespace SeleniumCookbook
{
    [TestClass]
    public class AutomatingElements
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
        public void TestMethod1()
        {
            string dropdownName = "etag";
            int elementsAmoung = 5;
            string value = "3";
            string selectedItemText = "не первый и не последний";

            _dropdown = (SelectElement)_driver.FindElementByName(dropdownName);
            // недопустим множественный выбор
            Assert.IsFalse(_dropdown.IsMultiple);
            // 5 элементов в списке 
            Assert.AreEqual(elementsAmoung, _dropdown.Options.Count);
            _dropdown.SelectByValue(value);
            Assert.AreEqual(_dropdown.SelectedOption.Text, selectedItemText);
        }
    }
}
