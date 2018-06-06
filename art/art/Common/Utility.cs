using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;

using System.Threading;
using System.Xml;

namespace Art.Common
{
    public class Utility
    {
        private static WindowsDriver<WindowsElement> orphanedSession;
        private static WindowsElement orphanedElement;
        private static string orphanedWindowHandle;

        ~Utility()
        {
            CleanupOrphanedSession();
        }

        public static void SleepSeconds(uint s)
        {
            Thread.Sleep(TimeSpan.FromSeconds(s));
        }




        public static WindowsDriver<WindowsElement> CreateDesktopSession()
        {
            DesiredCapabilities appCapabilites = new DesiredCapabilities();
            appCapabilites.SetCapability("app", "Root");
            return new WindowsDriver<WindowsElement>(new Uri(CommonTestSettings.WindowsApplicationDriverUrl), appCapabilites);

        }
        // find a existing/running app on desktop
        public static WindowsDriver<WindowsElement> AttachExistingSession(string appName)
        {
            WindowsDriver<WindowsElement> desktopSession = CreateDesktopSession();
            WindowsElement appWindow = desktopSession.FindElementByName(appName);

            string appWindowHandle = appWindow.GetAttribute("NativeWindowHandle");
            // to hex
            string hexWindowHandle = (int.Parse(appWindowHandle)).ToString("x");

            // create session by attaching to app top level window

            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("appTopLevelWindow", hexWindowHandle);

            return new WindowsDriver<WindowsElement>(new Uri(CommonTestSettings.WindowsApplicationDriverUrl), appCapabilities);



        }


        public static WindowsDriver<WindowsElement> CreateNewSession(string appId, string argument = null)
        {
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", appId);

            if (argument != null)
            {
                appCapabilities.SetCapability("appArguments", argument);
            }

            return new WindowsDriver<WindowsElement>(new Uri(CommonTestSettings.WindowsApplicationDriverUrl), appCapabilities);
        }

        public static bool CurrentWindowIsAlive(WindowsDriver<WindowsElement> remoteSession)
        {
            bool windowIsAlive = false;

            if (remoteSession != null)
            {
                try
                {
                    windowIsAlive = !string.IsNullOrEmpty(remoteSession.CurrentWindowHandle) && remoteSession.CurrentWindowHandle != "0";
                    windowIsAlive = true;
                }
                catch { }
            }

            return windowIsAlive;
        }






        public static WindowsElement GetOrphanedElement()
        {
            // Re-initialize orphaned session and element if they are compromised
            if (orphanedSession == null || orphanedElement == null)
            {
                InitializeOrphanedSession();
            }

            return orphanedElement;
        }

        public static WindowsDriver<WindowsElement> GetOrphanedSession()
        {
            // Re-initialize orphaned session and element if they are compromised
            if (orphanedSession == null || orphanedElement == null || string.IsNullOrEmpty(orphanedWindowHandle))
            {
                InitializeOrphanedSession();
            }

            return orphanedSession;
        }

        public static string GetOrphanedWindowHandle()
        {
            // Re-initialize orphaned session and element if they are compromised
            if (orphanedSession == null || orphanedElement == null || string.IsNullOrEmpty(orphanedWindowHandle))
            {
                InitializeOrphanedSession();
            }

            return orphanedWindowHandle;
        }

        private static void CleanupOrphanedSession()
        {
            orphanedWindowHandle = null;
            orphanedElement = null;

            // Cleanup after the session if exists
            if (orphanedSession != null)
            {
                orphanedSession.Quit();
                orphanedSession = null;
            }
        }

        private static void InitializeOrphanedSession()
        {
            // Create new calculator session and close the window to get an orphaned element
            CleanupOrphanedSession();
            orphanedSession = CreateNewSession(CommonTestSettings.CalculatorAppId);
            orphanedElement = orphanedSession.FindCalculatorTitleByAccessibilityId();
            orphanedWindowHandle = orphanedSession.CurrentWindowHandle;
            orphanedSession.Close();
        }


    }




}