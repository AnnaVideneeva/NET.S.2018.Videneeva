namespace Task5.Solution.Convertors
{
    public class ConvertorToLaTeX : IConvertor
    {
        public string ConvertHyperlink(string url, string text)
        {
            return "\\href{" + url + "}{" + text + "}";
        }

        public string ConvertPlainText(string text)
        {
            return text;
        }

        public string ConvertBoldText(string text)
        {
            return "\\textbf{" + text + "}";
        }
    }
}