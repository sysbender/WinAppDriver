using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        }
    }
}
