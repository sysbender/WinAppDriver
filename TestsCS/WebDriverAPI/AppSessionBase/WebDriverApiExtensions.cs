using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverAPI.AppSessionBase
{

    // extension method must defined in a non-generic static class
    static class WebDriverApiExtensions
    {
        // assembly scope - internal
        // extended method -https://weblogs.asp.net/scottgu/new-orcas-language-feature-extension-methods
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
