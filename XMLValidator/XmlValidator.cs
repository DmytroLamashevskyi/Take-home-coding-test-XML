namespace XMLValidator
{
    public interface IXmlValidator
    {
        bool DetermineXml(string str);
    }

    public class XmlValidator : IXmlValidator
    {
        private const char TAG_OPENNER = '<';
        private const char TAG_CLOSER = '>';
        private const char TAG_CLOSER_SLASH = '/';

        public bool DetermineXml(string str)
        {
            //Check inputs
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            Stack<string> tags = new Stack<string>();
            bool IsTagOpen = false;
            bool IsTagClose = false;
            string tag = string.Empty;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == TAG_OPENNER)
                {
                    IsTagOpen = true;
                    tag = string.Empty;
                }
                else if (str[i] == TAG_CLOSER)
                {
                    if (IsTagOpen)
                    {
                        if(string.IsNullOrEmpty(tag))
                        {
                            return false;
                        }
                        tags.Push(tag);
                    }
                    else
                    {
                        if (tags.Count == 0)
                        {
                            return false;
                        }

                        var popTag = tags.Pop();
                        if(tag != popTag)
                        {
                            return false;
                        }
                    }
                    IsTagOpen = false;
                    IsTagClose = false;
                }
                else if (IsTagOpen && str[i] == TAG_CLOSER_SLASH)
                {
                    IsTagOpen = false;
                    IsTagClose = true;
                }else if(IsTagOpen || IsTagClose)
                {
                    tag+=str[i];
                }
                 
            }

            return tags.Count == 0;

        }
    }
}