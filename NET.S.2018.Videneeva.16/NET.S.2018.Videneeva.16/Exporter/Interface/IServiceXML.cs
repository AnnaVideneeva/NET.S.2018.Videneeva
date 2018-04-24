using Exporter.Models;
using System.Xml.Linq;

namespace Exporter.Interface
{
    public interface IServiceXML
    {
        void Save(CollectionUrlAddresses collection);
        XDocument Get();
    }
}