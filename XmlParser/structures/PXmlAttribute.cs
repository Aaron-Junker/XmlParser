using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParser.structures
{
    internal class PXmlAttribute
    {
        public string name;
        public string value;
        public PXmlAttribute(string name, string value)
        {
            this.name = name;
            this.value = value;
        }
    }
}
