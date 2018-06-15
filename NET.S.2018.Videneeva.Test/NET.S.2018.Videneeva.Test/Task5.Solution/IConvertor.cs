namespace Task5.Solution.Convertors
{
    public interface IConvertor
    {
        string ConvertHyperlink(string text, string url);
        string ConvertPlainText(string text);
        string ConvertBoldText(string text);
    }
}