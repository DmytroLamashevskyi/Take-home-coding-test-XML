using XMLValidator;

namespace Tests
{
    public class UnitTest
    {    
        [Test]
        [TestCase("", ExpectedResult = false)] 
        [TestCase("<Design><Code>hello world</Code></Design>",ExpectedResult = true)]
        [TestCase("<Design><Code>hello world</Code><Code>hello world2</Code><Code>hello world3</Code></Design>", ExpectedResult = true)]
        [TestCase("<Design><Code>hello / world</Code></Design>", ExpectedResult = true)]
        [TestCase("<Design><>hello world</></Design>", ExpectedResult = false)] 
        [TestCase("<Design><Code>hello world</Code></Design><People>", ExpectedResult = false)]
        [TestCase("<People><Design><Code>hello world</People></Code></Design>", ExpectedResult = false)]
        [TestCase("<People age=”1”>hello world</People>", ExpectedResult = false)]
        [TestCase("<tutorial date=\"01/01/2000\">XML</tutorial>", ExpectedResult = false)]
        [TestCase("<a>1/12/2000</a>", ExpectedResult = true)]
        public bool ValidatorTest(string input)
        {
            IXmlValidator validator = new XmlValidator();
            return validator.DetermineXml(input);
        }
    }
}