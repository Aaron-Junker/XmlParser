using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using XmlParser.structures;

namespace XmlParser
{
    internal class Parser
    {

        private int pos;

        private string xmlDocument;

        private char c
        {
            get
            {
                try
                {
                    char c = xmlDocument[pos];
                    pos++;
                    return c;
                }
                catch (IndexOutOfRangeException)
                {
                    return '\0';
                }
            }
        }

        public XmlDocument Parse(string xmlDocument)
        {
            this.xmlDocument = xmlDocument;

            XmlElement[] elements = Array.Empty<XmlElement>();
            while (pos < xmlDocument.Length)
            {
                if (c == '<')
                {
                    //&& xmlDocument.ElementAt(pos + 1) != '?' && xmlDocument.ElementAt(pos + 1) != '!'
                    elements = elements.Append(parseOpeningTag()).ToArray();
                }
            }
           

            return new XmlDocument() { elements = elements };
        }

        public PXmlTagItem parseOpeningTag()
        {
            string tagName = String.Empty;
            PXmlAttribute[] attributes = Array.Empty<PXmlAttribute>();

            tagName += c;

            char charP;
            while ((charP = c) != '>')
            {
                if (charP == '/')
                {
                    if(charP != '>')
                    {
                        throw new InvalidMarkupException(pos);
                    }
                    
                    return new PXmlTagItem(tagName,false,true, String.Empty,attributes);
                }
                else if(charP == ' ')
                {
                    attributes = parseAttributesInTag();
                }
                else
                {
                    tagName += charP;
                }
                if (pos == xmlDocument.Length)
                {
                    return new PXmlTagItem(tagName, false, false, String.Empty, attributes);
                }
            }

            return new PXmlTagItem(tagName, false, false, String.Empty, attributes);
        }

        private PXmlAttribute[] parseAttributesInTag()
        {
            PXmlAttribute[] attributes = Array.Empty<PXmlAttribute>();

            string currentAttributeName = string.Empty;
            string currentAttributeContent = string.Empty;

            char charP;

            charP = c;

            while (charP != '>' && charP != '/')
            {
                currentAttributeName = "";
                currentAttributeContent = "";
                while (charP != '=')
                {
                    currentAttributeName += charP;
                    charP = c;
                }

                charP = c;

                if (charP != '"')
                {
                    throw new InvalidMarkupException(pos);
                }
                

                while ((charP = c) != '"')
                {
                    currentAttributeContent += charP;
                }

                charP = c;

                attributes = attributes.Append(new PXmlAttribute(currentAttributeName.TrimStart(), currentAttributeContent)).ToArray();

                if (charP != ' ' && charP != '>' && charP != '/')
                {
                    throw new InvalidMarkupException(pos);
                }
                
                if(charP == ' ' && xmlDocument.ElementAt(pos + 1) == '/')
                {
                    return attributes;
                }

                charP = c;
            }

            return attributes;
        }

        private PXmlName seperateNameAndNamespace(string fullName)
        {
            string[] nameAndNamespace = fullName.Split(':');
            if (nameAndNamespace.Length == 1)
            {
                return new PXmlName(nameAndNamespace[0]);
            }
            else if (nameAndNamespace.Length == 2)
            {
                return new PXmlName(nameAndNamespace[1], nameAndNamespace[0]);
            }
            else
            {
                throw new InvalidMarkupException(pos);
            }
        }
    }
}
