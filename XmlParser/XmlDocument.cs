using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParser
{
    public class XmlDocument
    {
        public XmlElement[] elements = Array.Empty<XmlElement>();
        public static XmlDocument Parse(string xml)
        {
            Parser p = new Parser();
            return p.Parse(xml);
        }
    }
}
