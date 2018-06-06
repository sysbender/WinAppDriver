using OpenQA.Selenium.Appium.Windows;
using System;

namespace Art
{
    static class WebDriverApiExtensions
    {
        internal static WindowsElement FindCalculatorTitleByAccessibilityId(this WindowsDriver<WindowsElement> session)
        {
            WindowsElement element;
            try
            {
                element = session.FindElementByAccessibilityId("AppNameTitle");
            }
            catch (InvalidOperationException)
            {
                element = session.FindElementByAccessibilityId("AppName");
            }
            return element;
        }

        internal static void DismissAlarmDialogIfThere(this WindowsDriver<WindowsElement> session)
        {
            try
            {
                session.FindElementByAccessibilityId("SecondaryButton").Click();
            }
            catch (InvalidOperationException)
            {
            }
        }
    }
}
