using Exporter.Interface;
using Exporter.Models;
using Mono.Web;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exporter.Service
{
    public class ParserURL : IParser
    {
        #region Fields

        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        #endregion Fields


        public CollectionUrlAddresses Parse(IReader reader)
        {
            if (ReferenceEquals(null, reader))
            {
                throw new ArgumentNullException(nameof(reader));
            }

            CollectionUrlAddresses collectionUrlAddresses = new CollectionUrlAddresses();

            foreach (var urlAddress in reader.Read())
            {
                if (IsCorrectURLAddress(urlAddress))
                {
                    UrlAddress obj = Create(urlAddress);
                    collectionUrlAddresses.UrlAddresses.Add(obj);
                }
            }

            return collectionUrlAddresses;
        }

        #region Private methods

        private UrlAddress Create(string urlAddress)
        {
            Uri uri = new Uri(urlAddress);

            return new UrlAddress()
            {
                Host = GetHost(uri),
                Uris = GetURIs(uri).ToList(),
                Parameters = GetParameters(uri).ToList()
            };

        }

        private Host GetHost(Uri uri)
        {
            return new Host() { Name = uri.Authority };
        }

        private IEnumerable<URI> GetURIs(Uri uri)
        {
            foreach (var segment in uri.Segments)
            {
                yield return new URI() { Segment = segment };
            }
        }

        private IEnumerable<Parameter> GetParameters(Uri uri)
        {
            foreach (var segment in HttpUtility.ParseQueryString(uri.Query).AllKeys)
            {
                yield return new Parameter() { Value = HttpUtility.ParseQueryString(uri.Query)[segment], Key = segment };
            }
        }

        private bool IsCorrectURLAddress(string urlAddress)
        {
            try
            {
                Uri uri = new Uri(urlAddress);
            }
            catch (ArgumentNullException ex)
            {
                Logger.Warn(new ArgumentException(ex.Message, nameof(urlAddress)), "The URL-address is null.");
                return false;
            }
            catch (UriFormatException ex)
            {
                Logger.Warn(new UriFormatException(ex.Message), $"The URL-address: {urlAddress} is incorrect.");
                return false;
            }

            return true;
        }

        #endregion Private methods
    }
}