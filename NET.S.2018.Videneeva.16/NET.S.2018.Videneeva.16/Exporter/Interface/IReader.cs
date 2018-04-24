using System.Collections.Generic;

namespace Exporter.Interface
{
    public interface IReader
    {
        IEnumerable<string> Read();
    }
}