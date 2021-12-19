
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSSelenium.UnitsEX
{
    [TestFixture]
    class Unit16ControllersExampl
        
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void StartSession()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/cart.html"); 
        }

        [Test]
        public void Te01 ()
        {
            // go to login 
            driver.FindElement(By.XPath("//*[@id = 'user-name']")).SendKeys("standard_user");
            driver.FindElement(By.XPath("//*[@id = 'password']")).SendKeys("secret_sauce"); 
            driver.FindElement(By.XPath("//*[@class = 'submit-button btn_action']")).Click();

            // prodacts page
            // drup down - 
            IWebElement pricesSorting = driver.FindElement(By.XPath("//*[@class='product_sort_container']"));
            SelectElement sorting = new SelectElement(pricesSorting);
            //בחירה מהמחיר הגבוה לנמוך
            sorting.SelectByValue("hilo");

            // הדפסת המחיר הכי גבוה מבין כל המוצרים

           IList <IWebElement> listOfPrices =   driver.FindElements(By.ClassName("inventory_item_price"));
            Console.WriteLine("the high price is: " + listOfPrices[0]);

            //לחיצה על ה - menu
            driver.FindElement(By.XPath("//*[@id = 'react-burger-menu-btn']")).Click();
            Thread.Sleep(1000);
            //לחיצה על ה - logOut
            driver.FindElement(By.XPath("//*[@id = 'logout_sidebar_link']")).Click();

        }
        [OneTimeTearDown]
        public void CloseSession()
        {
            driver.Quit();
        }

    }
}
