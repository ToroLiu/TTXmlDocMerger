using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace TTXmlDocHelper
{
    /// <summary>
    /// The utility class to merge C# Xml documents.
    /// </summary>
    public class XmlDocMerger
    {
        private XDocument _result = null;

        /// <summary>
        /// Return the XDocument result.
        /// </summary>
        /// <returns></returns>
        public XDocument GetXDocument()
        {
            return _result;
        }

        /// <summary>
        /// Return the XmlDocument result.
        /// </summary>
        /// <returns></returns>
        public XmlDocument GetXmlDocument()
        {
            string toXml = GetTempfilePath();
            if (string.IsNullOrEmpty(toXml))
                return null;

            XmlDocument result = new XmlDocument();
            result.Load(toXml);
            return result;
        }

        /// <summary>
        /// Return the xml result by temporary file path.
        /// </summary>
        /// <returns></returns>
        public string GetTempfilePath()
        {
            if (_result == null)
                return null;

            string toXml = System.IO.Path.GetTempFileName();
            using (XmlWriter xml = XmlWriter.Create(toXml))
            {
                _result.WriteTo(xml);
                xml.Flush();
            }
            return toXml;
        }

        public XmlDocMerger(string xmlPath)
        {
            _result = XDocument.Load(xmlPath);
        }

        public void AddDoc(string xmlPath)
        {
            if (_result == null)
            {
                _result = XDocument.Load(xmlPath);
            }
            else
            {
                var doc = XDocument.Load(xmlPath);

                _result.Root.XPathSelectElement("/doc/members").Add(
                    doc.Root.XPathSelectElement("/doc/members").Elements());
            }
        }
    }
}
