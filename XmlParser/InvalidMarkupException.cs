using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParser
{
    internal class InvalidMarkupException : Exception
    {
        public InvalidMarkupException() { }
        public InvalidMarkupException(int charNum) : base("Invalid Markup at char: "+ charNum) { }

        public InvalidMarkupException(int charNum, Exception inner) : base("Invalid Markup at char: " + charNum, inner) { }
    }
}
