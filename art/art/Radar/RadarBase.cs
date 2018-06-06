using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;
using Art;
using System.Xml;
using Art.Common;

namespace art.Radar
{
    public class RadarBase
    {

        protected static WindowsDriver<WindowsElement> session;

        public static void Setup(TestContext context)
        {
            if(session == null)
            {
                // cleanup
                TearDown();
                //launch
                try
                {
                    session = Utility.CreateNewSession(TestSettings.RadarAppId);
                }
                catch { }
                Utility.SleepSeconds(3);

                session = Utility.AttachExistingSession("Ondulus Radar Launcher");
                string  id = session.SessionId.ToString();
                var source = session.PageSource;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(source);

                context.WriteLine("session process id ="+id);
                context.WriteLine("session source =" + source);
                //session.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                //Assert.IsNotNull(session);
                //Assert.IsNotNull(session.SessionId);
            }

        }

        public static void TearDown()
        {
            if(session != null)
            {
                CloseRadar(session);
                session.Quit();
                session = null;
            }
        }

        public static void CloseRadar(WindowsDriver<WindowsElement> radarSession)
        {
            try
            {
                //close
                radarSession.Close();
                //verify

            }
            catch 
            {

            }
        }
    }
}
