using Exporter.Interface;
using Exporter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exporter.Service
{
    public class ConverterURI : IConverter
    {
        public XDocument ConverToXML(IReader reader, IParser parser, IServiceXML serviceXML)
        {          
            CollectionUrlAddresses collection = parser.Parse(reader);
            serviceXML.Save(collection);
            return serviceXML.Get();
        }
    }
}
