using Exporter.Models;

namespace Exporter.Interface
{
    public interface IParser
    {
        CollectionUrlAddresses Parse(IReader reader);
    }
}
