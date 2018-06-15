namespace Task5.Solution.Convertors
{
    public class ConvertorToHtml : IConvertor
    {
        public string ConvertHyperlink(string url, string text)
        {
            return "<a href=\"" + url + "\">" + text + "</a>";
        }

        public string ConvertPlainText(string text)
        {
            return text;
        }

        public string ConvertBoldText(string text)
        {
            return "<b>" + text + "</b>";
        }
    }
}