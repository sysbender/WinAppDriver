using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;
using Art;
using art.Common;
using System.Xml;
using Art.Common;

namespace art.Radar.Pages
{
    class LauncherPage
    {
        private WindowsDriver<WindowsElement> session;

        public LauncherPage(WindowsDriver<WindowsElement> session)
        {

            this.session = session;
            //[FindsBy(How = How.ClassName, Using = "WindowsForms10.COMBOBOX.app.0.13965fa_r30_ad1")]

            projectComboBox = session.FindElementByClassName("WindowsForms10.COMBOBOX.app.0.13965fa_r30_ad1");
    }


        
        private WindowsElement projectComboBox;

        public string getSelectedProjectName()
        {
            var proj = projectComboBox.Text;
             
            return proj;
        }

    }
}
