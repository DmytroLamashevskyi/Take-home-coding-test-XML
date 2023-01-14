using XMLValidator;

namespace Tests
{
    public class UnitTest
    {    
        [Test]
        [TestCase("", ExpectedResult = false)] 
        [TestCase("<Design><Code>hello world</Code></Design>",ExpectedResult = true)]
        [TestCase("<Design><Code>hello world</Code></Design><People>", ExpectedResult = false)]
        [TestCase("<People><Design><Code>hello world</People></Code></Design>", ExpectedResult = false)]
        [TestCase("<People age=”1”>hello world</People>", ExpectedResult = false)]
        public bool ValidatorTest(string input)
        {
            IXmlValidator validator = new XmlValidator();
            return validator.IsValid(input);
        }
    }
}