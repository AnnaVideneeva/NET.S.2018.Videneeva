using Exporter.Interface;
using Exporter.Models;
using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Exporter.Service
{
    public class ServiceXML : IServiceXML
    {
        #region Fields

        private string path;

        #endregion Fields

        #region Constructors

        public ServiceXML(string path)
        {
            this.Path = path;
        }

        #endregion Constructors

        #region Properties

        public string Path
        {
            get => this.path;

            set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.path = value;
            }
        }

        #endregion Properties

        #region IServiceXML implementation

        public void Save(CollectionUrlAddresses collection)
        {
            XmlSerializer xs = new XmlSerializer(typeof(CollectionUrlAddresses));
            using (Stream s = File.Create(this.Path))
            {
                xs.Serialize(s, collection);
            }       
        }

        public XDocument Get()
        {
             return XDocument.Load(this.Path);
        }

        #endregion IServiceXML implementation
    }
}