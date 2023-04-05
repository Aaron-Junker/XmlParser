using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParser
{
    internal class XmlComment : XmlElement
    {
        public XmlComment(string content)
        {
            XmlElementType = XmlElementType.comment;
            this.content = content;
        }
        public string content;
    }
}
