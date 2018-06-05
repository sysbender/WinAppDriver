using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebDriverAPI.AppSessionBase;
using OpenQA.Selenium.Appium.Windows;

namespace WebDriverAPI.TestCalculator
{
    /// <summary>
    /// Summary description for ElementName
    /// </summary>
    [TestClass]
    public class ElementName :CalculatorBase
    {
         #region Additional test attributes

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext context)
        {
            context.WriteLine("****************************************");
            Setup(context);

        }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            TearDown();

        }




        private TestContext testContextInstance;

        /// <summary>
        ///  Gets or sets the test context which provides
        ///  information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }


        #endregion

        [TestMethod]
        public void GetElementTagName()
        {
            WindowsElement header = session.FindCalculatorTitleByAccessibilityId();
            Assert.AreEqual("ControlType.Text", header.TagName);

            WindowsElement navButton = session.FindElementByAccessibilityId("NavButton");
            Assert.AreEqual("ControlType.Button", navButton.TagName);
        }



        [TestMethod]
        public void GetElementTageNameError_staleElement()
        {


            Console.WriteLine("===========hahaha==============");
            try
            {
                var tagName = GetStaleElement().TagName;
                Assert.Fail("Exception should have been thrown");

            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual(ErrorStrings.StaleElementReference, ex.Message);
            }


        }
    }
}
