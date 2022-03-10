using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace QADemoProject.SupportClasses
{
    //Not used in demo but can be used for rest api validation
    public static class XMLStructureValidator
    {

        public static string XmlTagValidator(string xmlFormat)
        {
            XmlDocument xmltest = new XmlDocument();
            xmltest.LoadXml(xmlFormat);
            string parentSplit = null;
            XmlNodeList nodeListName = xmltest.SelectNodes("Xpath");
            foreach (XmlNode xNode in nodeListName)
            {
                XmlNode parent = xNode.ParentNode;

                if (parent.Attributes != null && parent.Attributes["split"] != null)
                {
                    parentSplit = parent.Attributes["split"].Value;
                }
            }
            return parentSplit;

        }



        public static Dictionary<string, string> ReadXMLApplicantTagValue(List<string> tagsList, string applicantsfilepath, string applicationdatafilepath)
        {
            Dictionary<string, string> xmlDictionary = new Dictionary<string, string>();
            XmlDocument xmlApplicants = new XmlDocument();
            XmlDocument xmlApplicationData = new XmlDocument();
            xmlApplicants.Load(applicantsfilepath);// write xml path
            xmlApplicationData.Load(applicationdatafilepath);// write xml path
            foreach (string tagElement in tagsList)
            {
                XmlNodeList xnList = xmlApplicants.GetElementsByTagName(tagElement);

                if (xnList.Count == 0)
                {
                    xnList = xmlApplicationData.GetElementsByTagName(tagElement);
                    foreach (XmlNode xn in xnList)
                    {
                        xmlDictionary.Add(tagElement, xn.InnerXml);

                    }
                }
                else
                {
                    foreach (XmlNode xn in xnList)
                    {
                        xmlDictionary.Add(tagElement, xn.InnerXml);

                    }
                }


            }

            return xmlDictionary;
        }
    }
}