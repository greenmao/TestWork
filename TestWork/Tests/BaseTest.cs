using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using TestWork.Utils;

namespace TestWork.Tests
{
    class BaseTest
    {
        public WebDriverManager webDriverManager;

        [OneTimeSetUp]
        public void beforeClass()
        {
            webDriverManager = new WebDriverManager();
            webDriverManager.Init();
        }

        [TearDown]
        public void afterTest()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var screenShot = webDriverManager.getWebDriver.TakeScreenshot();
                string path = AppDomain.CurrentDomain.BaseDirectory + "screenshots\\screenshot " + DateTime.Now.ToString("R").Trim().Replace(",", "").Replace(":", "").Replace(".", "") + ".png";
                screenShot.SaveAsFile(path);
            }
        }

        [OneTimeTearDown]
        public void afterClass()
        {
            webDriverManager.Close();
        }
    }
}
