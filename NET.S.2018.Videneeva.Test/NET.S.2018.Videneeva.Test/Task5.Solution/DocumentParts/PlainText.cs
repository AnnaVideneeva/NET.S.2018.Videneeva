using Task5.Solution.Convertors;

namespace Task5.Solution.DocumentParts
{
    public class PlainText : DocumentPart
    {
        public override string Convert(IConvertor convertor)
        {
            return convertor.ConvertPlainText(this.Text);
        }
    }
}