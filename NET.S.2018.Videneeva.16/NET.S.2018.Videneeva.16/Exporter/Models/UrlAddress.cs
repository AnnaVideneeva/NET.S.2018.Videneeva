using System.Collections.Generic;
using System.Xml.Serialization;

namespace Exporter.Models
{
    public class UrlAddress
    {
        [XmlElement("host")]
        public Host Host { get; set; }

        [XmlElement("uri")]
        public List<URI> Uris { get; set; }

        [XmlArray("parameters")]
        [XmlArrayItem("parameter")]
        public List<Parameter> Parameters { get; set; }
    }
}
