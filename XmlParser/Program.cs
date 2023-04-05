using XmlParser.structures;

namespace XmlParser
{
    internal class Program
    {
        public static void Main()
        {
            XmlDocument tag = XmlDocument.Parse("<abrer a=\"a\" s=\"a\" />");
            System.Console.WriteLine(tag);
        }
    }
}
