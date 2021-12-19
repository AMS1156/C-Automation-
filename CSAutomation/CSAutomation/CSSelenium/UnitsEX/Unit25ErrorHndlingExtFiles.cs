using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml;

namespace CSSelenium.UnitsEX
{
    [TestFixture]
    class Unit25ErrorHndlingExtFiles
    {

        IWebDriver driver;
        WebDriverWait wait;
        [OneTimeSetUp]
        public void StartSession()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            //סינכרון על ידי חיפוש אלמנט
            driver.Navigate().GoToUrl(GetData("URL"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));

        }


        [Test]
        public void Test01 ()
        {
            try
            {
                SelectElement s = new SelectElement(driver.FindElement(By.Id("customerCurrency")));
                s.SelectByText(GetData("CURRENCY"));

                driver.FindElement(By.LinkText("Books")).Click();
                IList actualPrices = driver.FindElements(By.ClassName(".price.actual-price"));

                string expected = GetData("PRICE");
                foreach (IWebElement items in actualPrices)
                {

                    Assert.AreEqual(expected, items.Text);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("test is faild : " + e.Message);
                Assert.Fail("test is faild : " + e.Message);
                
            }
           
        }

        [OneTimeTearDown]
        public void CloseSession()
        {
            driver.Quit();
        }

        public string GetData (string data)
        {
            using(XmlReader reader = XmlReader.Create(@"C:\Automations\CSAutomation\Synchronisation\Envirenmet.xml"))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        if (reader.Name.ToString().Equals(data))
                        {
                            return reader.ReadString();
                        }
                    }

                }
               
            }
            return "Null";
        }
    }
}
