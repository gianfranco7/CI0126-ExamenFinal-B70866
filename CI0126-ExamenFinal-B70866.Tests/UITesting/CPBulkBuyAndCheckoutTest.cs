﻿// Generated by Selenium IDE
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
namespace CI0126_ExamenFinal_B70866.Tests.UITesting
{
    [TestFixture]
    public class CPBulkBuyAndCheckoutTest
    {
        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }
        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }
        [Test]
        public void cPBulkBuyAndCheckout()
        {
            driver.Navigate().GoToUrl("https://localhost:44338/");
            driver.Manage().Window.Size = new System.Drawing.Size(1296, 829);
            driver.FindElement(By.LinkText("Ver Productos")).Click();
            driver.FindElement(By.LinkText("Comprar en paquete")).Click();
            driver.FindElement(By.LinkText("Proceder a Checkout")).Click();
            driver.FindElement(By.Id("address")).Click();
            driver.FindElement(By.Id("address")).SendKeys("Costa Rica");
            driver.FindElement(By.CssSelector(".btn")).Click();
        }
    }
}