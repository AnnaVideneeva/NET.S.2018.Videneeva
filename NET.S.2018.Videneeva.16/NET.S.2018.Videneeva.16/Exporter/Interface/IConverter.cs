using System.Xml.Linq;

namespace Exporter.Interface
{
    public interface IConverter
    {
        XDocument ConverToXML(IReader reader, IParser parser, IServiceXML serviceXML);
    }
}