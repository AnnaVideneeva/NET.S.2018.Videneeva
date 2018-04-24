using System;
using System.Collections.Generic;
using System.IO;
using Exporter.Interface;

namespace Exporter.Service
{
    public class FileReader : IReader
    {
        #region Fields

        private string path;

        #endregion Fields

        #region Constructors

        public FileReader(string path)
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

        #region IReader implementation

        public IEnumerable<string> Read()
        {
            using (StreamReader streamReader = new StreamReader(this.Path))
            {
                while (!streamReader.EndOfStream)
                {
                    yield return streamReader.ReadLine()?.Trim();
                }
            }
        }

        #endregion IReader implementation
    }
}