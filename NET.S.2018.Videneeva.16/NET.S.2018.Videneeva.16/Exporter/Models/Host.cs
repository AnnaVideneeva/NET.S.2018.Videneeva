using System.Xml.Serialization;

namespace Exporter.Models
{
    public class Host
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}