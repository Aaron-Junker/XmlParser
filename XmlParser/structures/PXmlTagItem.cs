using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParser.structures
{
    internal class PXmlTagItem : XmlElement
    {
        public readonly bool isStandaloneTag;
        public readonly bool isEndTag;
        public readonly string tagName;
        public readonly string xmlNamespace;
        public PXmlAttribute[] arguments;
        public PXmlTagItem(string tagName, bool isEndTag, bool isStandaloneTag, string xmlNamespace, PXmlAttribute[] arguments)
        {
            
            this.isStandaloneTag = isStandaloneTag;
            this.isEndTag = isEndTag;
            this.tagName = tagName;
            this.arguments = arguments;
            this.xmlNamespace = xmlNamespace;
        }
    }
}
