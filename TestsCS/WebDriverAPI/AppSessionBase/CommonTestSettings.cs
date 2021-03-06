﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverAPI.AppSessionBase
{
    class CommonTestSettings
    {
        public const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";

        public const string AlarmClockAppId = "Microsoft.WindowsAlarms_8wekyb3d8bbwe!App";
        public const string CalculatorAppId = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";
        public const string DesktopAppId = "Root";
        public const string EdgeAppId = "Microsoft.MicrosoftEdge_8wekyb3d8bbwe!MicrosoftEdge";
        public const string ExplorerAppId = @"C:\Windows\System32\explorer.exe";
        public const string NotepadAppId = @"C:\Windows\System32\notepad.exe";

        public const string EdgeAboutBlankURL = "about:blank";
        public const string EdgeAboutFlagsURL = "about:flags";
        public const string EdgeAboutTabsURL = "about:tabs";

        public const string TestFileName = @"TestFile";
        public const string TestFolderLocation = @"%TEMP%";
    }

    public class ErrorStrings
    {

        public const string ElementNotVisible = "An element command could not be completed because the element is not pointer- or keyboard interactable.";
        public const string NoSuchElement = "An element could not be located on the page using the given search parameters.";
        public const string NoSuchWindow = "Currently selected window has been closed";
        public const string StaleElementReference = "An element command failed because the referenced element is no longer attached to the DOM.";
        public const string UnimplementedCommandLocator = "Unexpected error. Unimplemented Command: {0} locator strategy is not supported";
        public const string UnimplementedCommandTimeoutType = "Unexpected error. Unimplemented Command: {0} timeout type is not supported";
        public const string XPathLookupError = "Invalid XPath expression: {0} (XPathLookupError)";
    }
}
