using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace WebDriverAPI.AppSessionBase
{
    public class CalculatorBase
    {

        protected static WindowsDriver<WindowsElement> session;
        protected static RemoteTouchScreen touchScreen;
        private static WindowsElement header;


        public static void Setup(TestContext context)
        {
            // launch calculator if it is not yet launched

            if(session == null || touchScreen == null)
            {
                session = Utility.CreateNewSession(CommonTestSettings.CalculatorAppId);
                Assert.IsNotNull(session);
                Assert.IsNotNull(session.SessionId);

                try
                {
                    header = session.FindElementByAccessibilityId("Header");
                }
                catch
                {
                    header = session.FindElementByAccessibilityId("ContentPresenter");
                }

                Assert.IsNotNull(header);

                // init touch screen object
                touchScreen = new RemoteTouchScreen(session);
                Assert.IsNotNull(touchScreen);
            }

            // ensure that calculator is in standard mode
            if(!header.Text.Equals("Standard", StringComparison.OrdinalIgnoreCase))
            {
                session.FindElementByAccessibilityId("NavButton").Click();
                Thread.Sleep(TimeSpan.FromSeconds(1));

                var splitViewPane = session.FindElementByClassName("SplitViewPane");
                splitViewPane.FindElementByName("Standard Calculator").Click();
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Assert.IsTrue(header.Text.Equals("Standard", StringComparison.OrdinalIgnoreCase));
            }


        }

        public static void TearDown()
        {
            header = null;

            touchScreen = null;
            if(session != null)
            {
                session.Quit();
                session = null;
            }

        }


        protected static WindowsElement GetStaleElement()
        {
            session.FindElementByAccessibilityId("ClearMemoryButton").Click();
            session.FindElementByAccessibilityId("clearButton").Click();
            session.FindElementByAccessibilityId("memButton").Click();

            try
            {
                //locate the memory pivot item tab that is displayed in expanded mode
                session.FindElementByAccessibilityId("MemoryLabel").Click();
            }
            catch
            {
                // open the memory flyout when the calculator is in compact mode
                session.FindElementByAccessibilityId("MemoryButton").Click();
            }


            Thread.Sleep(TimeSpan.FromSeconds(1));
            WindowsElement staleElement = session.FindElementByAccessibilityId("MemoryListView").FindElementByName("0") as WindowsElement;

            session.FindElementByAccessibilityId("ClearMemory").Click();
            header.Click();
            Thread.Sleep(TimeSpan.FromSeconds(1.5));
            return staleElement;

        }

    }
}
