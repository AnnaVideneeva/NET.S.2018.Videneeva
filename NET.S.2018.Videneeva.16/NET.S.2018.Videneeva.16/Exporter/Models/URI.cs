using System.Xml.Serialization;

namespace Exporter.Models
{
    public class URI
    {
        [XmlElement("segment")]
        public string Segment { get; set; }
    }
}
