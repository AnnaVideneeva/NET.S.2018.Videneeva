using Task5.Solution.Convertors;

namespace Task5.Solution.DocumentParts
{
    public class BoldText : DocumentPart
    {
        public override string Convert(IConvertor convertor)
        {
            return convertor.ConvertBoldText(this.Text);
        }
    }
}
