using System.Collections.Generic;
using System.Xml.Serialization;

namespace Exporter.Models
{
    [XmlRoot("urlAddresses")]
    public class CollectionUrlAddresses
    {
        public CollectionUrlAddresses()
        {
            UrlAddresses = new List<UrlAddress>();
        }

        [XmlElement("urlAddress")]
        public List<UrlAddress> UrlAddresses { get; set; }
    }
}