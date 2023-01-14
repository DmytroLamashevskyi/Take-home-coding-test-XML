namespace XMLValidator
{
    public interface IXmlValidator
    {
       bool IsValid(string str);
    }

    public class XmlValidator : IXmlValidator
    {
        public bool IsValid(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }




        }
    }
}