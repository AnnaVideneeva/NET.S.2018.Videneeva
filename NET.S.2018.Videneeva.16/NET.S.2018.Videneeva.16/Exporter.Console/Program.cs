using Exporter.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exporter.Console
{
    public class Program
    {
        private static readonly string PathTXT = "URL_Adress.txt";
        private static readonly string PathXML = "URL_Adress.xml";

        static void Main(string[] args)
        {
            ServiceXML serviceXML = new ServiceXML(PathXML);
            ConverterURI converterURI = new ConverterURI();

            converterURI.ConverToXML(new FileReader(PathTXT), new ParserURL(), serviceXML);

            System.Console.Write(serviceXML.Get());

            System.Console.ReadKey();
        }
    }
}
