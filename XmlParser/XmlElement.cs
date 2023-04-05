using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParser
{
    public abstract class XmlElement
    {
        public XmlElementType XmlElementType { get; set; }
    }

    public enum XmlElementType
    {
        tag,
        text,
        comment,
        doctype,
        entity,
    }
}
