using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;



namespace art.Common
{


    // https://stackoverflow.com/questions/1649027/how-do-i-print-out-a-tree-structure

    public class PageSource
    {
        //private XmlDocument xmlDoc;
        //private string txtTree ="";
        //private string indent = "";
        private XmlDocument xmlDoc { get; set; }
        private string txtTree { get; set; }

        public PageSource(WindowsDriver<WindowsElement> appSession)
        {
            string source = appSession.PageSource;
            xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(source);

        }

        public PageSource(string xmlPageSource)
        {
            xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlPageSource);
        }


        public string dumpNodeTree()
        {
            txtTree = "";
            NodeToTree(xmlDoc, "", true);
            return txtTree;
        }


        public void NodeToTree(XmlNode node, string indent, bool last)
        {
            // each node : name = value; 
            string line = indent + "+- " + node.Name + " : ";
            // dump the 5 most important attribute
            var attributeNames = new string[] { "Name" , "LocalizedControlType", "FrameworkId", "ClassName", "AutomationId"};
            foreach (var attributeName in attributeNames )
            {
                string attributeValue = NodeAttribute(node, attributeName);
                if (!string.IsNullOrEmpty(attributeValue))
                {
                    line = line + attributeName + " = " + attributeValue + " ; ";
                }

            }

            line += "\n";
            txtTree += line;

            indent += last ? "   " : "|  ";

            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                NodeToTree(node.ChildNodes[i], indent, i == node.ChildNodes.Count - 1);
            }

        }

        // if node has the attribute, then return "attributeName=attributeValue" 
        // otherwise return ""
        public string NodeAttribute(XmlNode node, string attributeName)
        {
            string result = "";
            XmlElement xmlElement = node as XmlElement;
            if(xmlElement != null && xmlElement.HasAttribute(attributeName))
            {
                result = node.Attributes[attributeName].Value;
            }
            return result;
        }
    }
}
