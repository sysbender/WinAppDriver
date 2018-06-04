using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace WebDriverAPI.AppSessionBase
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

        private static void CleanupOrphanedSession()
        {
            orphanedWindowHandle = null;
            orphanedElement = null;
            if(orphanedSession != null)
            {
                orphanedSession.Quit();
                orphanedSession = null;
            }
        }

        public static WindowsDriver<WindowsElement> CreateNewSession(string appId, string argument = null)
        {
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", appId);
            if(argument != null)
            {
                appCapabilities.SetCapability("appArguments", argument);
            }

            return new WindowsDriver<WindowsElement>(new Uri(CommonTestSettings.WindowsApplicationDriverUrl), appCapabilities);
        }

        public static bool CurrentWindowIsAlive(WindowsDriver<WindowsElement> remoteSession)
        {
            bool windowIsAlive = false;
            if(remoteSession != null)
            {
                try
                {
                    windowIsAlive = !string.IsNullOrEmpty(remoteSession.CurrentWindowHandle)
                        && remoteSession.CurrentWindowHandle != "0";
                    windowIsAlive = true; //???
                }
                catch { }
            }

            return windowIsAlive;
        }

        public static WindowsElement GetOrphanedElement()
        {
            // re-initalize orphaned sessin and element if they are comprimised
            if(orphanedSession == null || orphanedElement == null)
            {
                InitializeOrphanedSessoin();
            }
            return orphanedElement;
        }

        private static void InitializeOrphanedSessoin()
        {
            //create new calculator session and close the window to get an orphaned element
            CleanupOrphanedSession();
            orphanedSession = CreateNewSession(CommonTestSettings.CalculatorAppId);
            orphanedElement = orphanedSession.FindCalculatorTitleByAccessibilityId();
            orphanedWindowHandle = orphanedSession.CurrentWindowHandle;
            orphanedSession.Close();
        }
    }
}
