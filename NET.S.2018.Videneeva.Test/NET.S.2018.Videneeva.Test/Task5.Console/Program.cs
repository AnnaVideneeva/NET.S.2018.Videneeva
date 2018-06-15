using System.Collections.Generic;
using Task5.Solution;
using Task5.Solution.Convertors;
using Task5.Solution.DocumentParts;

namespace Task5.Console
{ 
    class Program
    {
        static void Main(string[] args)
        {
            List<DocumentPart> parts = new List<DocumentPart>
                {
                    new PlainText {Text = "Some plain text"},
                    new Hyperlink {Text = "google.com", Url = "https://www.google.by/"},
                    new BoldText {Text = "Some bold text"}
                };

            Document document = new Document(parts);

            System.Console.WriteLine(document.Convert(new ConvertorToHtml()));
            System.Console.WriteLine(document.Convert(new ConvertorToLaTeX()));
            System.Console.WriteLine(document.Convert(new ConvertorToPlainText()));
        }
    }
}
