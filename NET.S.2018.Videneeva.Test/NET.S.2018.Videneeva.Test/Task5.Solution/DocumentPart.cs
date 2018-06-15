using Task5.Solution.Convertors;

namespace Task5.Solution
{
    public abstract class DocumentPart
    {
        public string Text { get; set; }

        public abstract string Convert(IConvertor convertor);
    }
}