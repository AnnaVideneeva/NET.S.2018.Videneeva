namespace Task5.Solution.Convertors
{
    public class ConvertorToPlainText : IConvertor
    {
        public string ConvertHyperlink(string url, string text)
        {
            return text + " [" + url + "]";
        }

        public string ConvertPlainText(string text)
        {
            return text;
        }

        public string ConvertBoldText(string text)
        {
            return "**" + text + "**";
        }
    }
}
