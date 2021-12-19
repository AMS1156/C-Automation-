using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml;

namespace CSSelenium.UnitsEX
{
    [TestFixture]
    class Unit_29_Actions_And_Roporting
    {
        IWebDriver driver;
        Actions actions;
        ExtentReports extent;
        ExtentTest test;
        //WebDriverWait wait;
        [OneTimeSetUp]
        public void StartSession()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            //סינכרון על ידי חיפוש אלמנט
            driver.Navigate().GoToUrl("https://marcojakob.github.io/dart-dnd/basic/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            actions = new Actions(driver);
            extent = new ExtentReports(@"C:\Automations\Test\Report\myReports");
        }


        [Test]
        public void Test01()
        {
            test = extent.StartTest("test drag & drop", "test resolt of drag and drop");
            try
            {
                
                IWebElement drag = driver.FindElement(By.ClassName("document"));
                test.Log(LogStatus.Pass, "drag element such");
                IWebElement drop = driver.FindElement(By.ClassName("trash"));
                test.Log(LogStatus.Pass, "drog element such");
                actions.DragAndDrop(drag, drop).Build().Perform();
                IWebElement dropAfter = driver.FindElement(By.CssSelector(".rash.full"));
                test.Log(LogStatus.Pass, "dropAfter element such");

                Assert.IsTrue(dropAfter.Displayed);
                test.Log(LogStatus.Pass, "test passed");


            }
            catch (Exception e)
            {

                test.Log(LogStatus.Fail, "test is faild : " + e.Message);
                Assert.Fail("test is faild : " + e.Message + test.AddScreencast(ScreenShot()));

            }


            finally
            {
               // driver.Navigate().GoToUrl("https://marcojakob.github.io/dart-dnd/basic/");
            }
        }

        [TearDown]
        public void aftherMethod()
        {
            extent.EndTest(test);
            driver.Quit();
        }

        [OneTimeTearDown]
        public void CloseSession()
        {
            extent.Flush();
            extent.Close();
            driver.Quit();
        }

        public string ScreenShot()
        {
            string location = @"C:\Automations\Test\Report\ScreenShot_" + RandomNumber()+".Png";
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(location, ScreenshotImageFormat.Png);
            return location;
            
        }

        public int RandomNumber()
        {
            Random random = new Random();
            return random.Next(1, 9999999);
        }
    }
}
