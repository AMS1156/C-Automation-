using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace CSSelenium.UnitsEX
{
    [TestFixture]
    class Unit22Synchronisation
    {

        IWebDriver driver;
        WebDriverWait wait;
        [OneTimeSetUp]
        public void StartSession()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            //סינכרון על ידי חיפוש אלמנט
            driver.Navigate().GoToUrl(@"C:\Automations\CSAutomation\Synchronisation\Old-page.html");
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));

        }


        [Test]
        public void Test01 ()
        {
            // המתנה הכי פשוטה - של סי שארפ לפי מספר שניות שנשים כפרמטר
            //Thread.Sleep(2000);

            //המתנה על ידי בדיקה עם אלמנט מסויים נמצא ב - DOM
           // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("new_title")));

            //המתנה עלי ידי בדיקה עם האלמנט מוצג בדף
           wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("new_title")));
            IWebElement title = driver.FindElement(By.Id("new_title"));

        }

        [OneTimeTearDown]
        public void CloseSession()
        {
            driver.Quit();
        }
    }
}
