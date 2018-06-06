using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


// https://stackoverflow.com/questions/1649027/how-do-i-print-out-a-tree-structure
namespace art.Common
{
    class PageSource
    {
        private XmlDocument xmlDoc;
        private string txtDoc ="";
        private string indent = "";


        public PageSource(WindowsDriver<WindowsElement> appSession)
        {
            string source = appSession.PageSource;
            xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(source);

        }


        // handle xmldoc
        public static string DumpSession()
        {




            return "";
        }

        // tranversal the xml 
        private  void FindAllNodes(XmlNode node)
        {
            indent += "\t";
            //txtDoc += "\n";
            foreach (XmlNode n in node.ChildNodes)
            {
                FindAllNodes(n);
            }
                
        }

    }
}
