using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using art.Radar.Pages;
namespace art.Radar.Tests
{
    [TestClass]
    public class UnitTestDemo : RadarBase
    {

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Setup(context);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TearDown();
        }


        [TestMethod]
        public void TestMethod1()
        {
            var page = new LauncherPage(session);
            var text = page.getSelectedProjectName();
            Console.Out.WriteLine("---------------------------------------------");
            Console.Out.WriteLine(text);
        }
    }
}
