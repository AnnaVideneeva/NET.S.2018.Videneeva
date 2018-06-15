using System;
using System.Collections.Generic;
using Task5.Solution.Convertors;

namespace Task5.Solution
{
    public class Document
    {
        private List<DocumentPart> parts;

        public Document(IEnumerable<DocumentPart> parts)
        {
            if (parts == null)
            {
                throw new ArgumentNullException(nameof(parts));
            }
            this.parts = new List<DocumentPart>(parts);
        }

        public string Convert(IConvertor convertor)
        {
            string output = string.Empty;

            foreach (var part in this.parts)
            {
                output += $"{part.Convert(convertor)}\n";
            }

            return output;
        }
    }
}
