using Task5.Solution.Convertors;

namespace Task5.Solution.DocumentParts
{
    public class Hyperlink : DocumentPart
    {
        public string Url { get; set; }

        public override string Convert(IConvertor convertor)
        {
            return convertor.ConvertHyperlink(this.Text, this.Url);
        }
    }
}
