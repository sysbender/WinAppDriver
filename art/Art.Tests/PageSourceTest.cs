// <copyright file="PageSourceTest.cs">Copyright ©  2018</copyright>
using System;
using System.Xml;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using art.Common;

namespace art.Common.Tests
{
    /// <summary>This class contains parameterized unit tests for PageSource</summary>
    [PexClass(typeof(PageSource))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class PageSourceTest
    {
        /// <summary>Test stub for .ctor(WindowsDriver`1&lt;WindowsElement&gt;)</summary>
        [PexMethod]
        public PageSource ConstructorTest(WindowsDriver<WindowsElement> appSession)
        {
            PageSource target = new PageSource(appSession);
            return target;
            // TODO: add assertions to method PageSourceTest.ConstructorTest(WindowsDriver`1<WindowsElement>)
        }

        /// <summary>Test stub for .ctor(String)</summary>
        [PexMethod]
        public PageSource ConstructorTest01(string xmlPageSource)
        {
            PageSource target = new PageSource(xmlPageSource);
            return target;
            // TODO: add assertions to method PageSourceTest.ConstructorTest01(String)
        }

        /// <summary>Test stub for NodeToTree(XmlNode, String, Boolean)</summary>
        [PexMethod]
        public void NodeToTreeTest(
            [PexAssumeUnderTest]PageSource target,
            XmlNode node,
            string indent,
            bool last
        )
        {
            target.NodeToTree(node, indent, last);
            // TODO: add assertions to method PageSourceTest.NodeToTreeTest(PageSource, XmlNode, String, Boolean)
        }

        /// <summary>Test stub for dumpNodeTree()</summary>
        [PexMethod]
        public string dumpNodeTreeTest([PexAssumeUnderTest]PageSource target)
        {
            string result = target.dumpNodeTree();
            return result;
            // TODO: add assertions to method PageSourceTest.dumpNodeTreeTest(PageSource)
        }
    }
}
