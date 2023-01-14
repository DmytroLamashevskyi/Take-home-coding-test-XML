namespace XMLValidator
{
    public interface IXmlValidator
    {
        bool DetermineXml(string str);
    }

    public class XmlValidator : IXmlValidator
    {
        public bool DetermineXml(string str)
        {
            //Check inputs
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            Stack<string> tags = new Stack<string>();
            bool IsTagOpen = false;
            bool IsTagClosing = false;
            string tag = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '<')
                {
                    IsTagOpen = true;
                    tag = string.Empty;
                }
                else if (str[i] == '>')
                {
                    if (IsTagOpen)
                    {
                        tags.Push(tag);
                    }
                    else
                    {
                        var popTag = tags.Pop();
                        if(tag != popTag)
                        {
                            return false;
                        }
                    }
                    IsTagOpen = false;
                    IsTagClosing = false;
                }
                else if (str[i] == '/')
                {
                    IsTagOpen = false;
                    IsTagClosing = true;
                }else if(IsTagOpen || IsTagClosing)
                {
                    tag+=str[i];
                }
                 
            }

            return tags.Count == 0;

        }
    }
}