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
            Setup(context);

        }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            TearDown();

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




    }
}
