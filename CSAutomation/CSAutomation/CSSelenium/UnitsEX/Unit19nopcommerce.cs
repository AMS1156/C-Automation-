using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace CSSelenium.UnitsEX
{
    [TestFixture]
    class Unit19nopcommerce
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void StartSession()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demo.nopcommerce.com/camera-photo");
        }

        [Test]
        public void Test01()
        {
           IWebElement priceSorting = driver.FindElement(By.Id("products-orderby"));
            SelectElement sorting = new SelectElement(priceSorting);
            sorting.SelectByText("Price: Low to High");

            int actual = driver.FindElements(By.ClassName("item-box")).Count  ;
            int expected = 3;
            Assert.AreEqual(expected,actual);

        }
        [Test]
        public void Test02()
        {
            String[] expected = { "Nikon D5500 DSLR", "Leica T Mirrorless Digital Camera", "Apple iCam"};
            IList<IWebElement> actual = driver.FindElements(By.ClassName("product-title"));
            for (int i = 0; i < actual.Count; i++)
            {
                Console.WriteLine("the hhhh:" +actual[i].FindElement(By.TagName("a")).Text);
                Assert.AreEqual(expected[i], actual[i].FindElement(By.TagName("a")).Text);
            }
        }

        [Test]
        public void Test03 ()
        {
            IList<IWebElement> dirug = driver.FindElements(By.ClassName("rating"));
            string value;
            foreach (var actual in dirug)
            {
                value = actual.FindElement(By.TagName("div")).GetAttribute("style").Replace(" ", "").Split(':')[1].Split('%')[0];
                Assert.IsTrue(Int32.Parse(value)>=0);
            }
        }

        [OneTimeTearDown]
        public void CloseSession()
        {
            driver.Quit();
        }

    }
}
