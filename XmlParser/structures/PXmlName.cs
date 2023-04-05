using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParser.structures
{
    internal class PXmlName
    {
        public string name;
        public string? xmlNamespace;
        public PXmlName(string name, string? xmlNamespace = null)
        {
            this.name = name;
            this.xmlNamespace = xmlNamespace;
        }
    }
}
