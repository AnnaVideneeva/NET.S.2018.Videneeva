using System.Xml.Serialization;

namespace Exporter.Models
{
    public class Parameter
    {
        [XmlAttribute("value")]
        public string Value { get; set; }

        [XmlAttribute("key")]
        public string Key { get; set; }
    }
}