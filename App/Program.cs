using XMLValidator;

namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IXmlValidator validator = new XmlValidator();
            Console.WriteLine(validator.DetermineXml("<Design><Code>hello world</Code></Design>"));
        }
    }
}