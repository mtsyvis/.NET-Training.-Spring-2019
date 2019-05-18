using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using BLL.Interface.Interfaces;
using NET1.S._2019.Tsyvis._22.Interfaces;

namespace BLL
{
    /// <summary>
    /// Provide service to exporting uri to xml.
    /// </summary>
    /// <seealso cref="NET1.S._2019.Tsyvis._22.Interfaces.IExportService" />
    public class UriToXmlExportService : IExportService
    {
        private IUriReader reader;

        private ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UriToXmlExportService"/> class.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="logger">The logger.</param>
        public UriToXmlExportService(IUriReader reader, ILogger logger)
        {
            this.reader = reader;
            this.logger = logger;
        }

        /// <summary>
        /// Exports the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        public void Export(string source, string destination)
        {
            var uris = this.GetUris(this.reader.ReadUris(source));

            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", "yes"));

            XmlElement root = doc.CreateElement("urlAddresses");

            foreach (var uri in uris)
            {
                XmlElement urlAddress = doc.CreateElement("urlAddress");
                XmlElement host = doc.CreateElement("hostName");
                XmlAttribute name = doc.CreateAttribute("name");
                name.Value = uri.Host;
                host.Attributes.Append(name);

                XmlElement uriElement = doc.CreateElement("uri");
                
                foreach (var segment in uri.Segments.Skip(1))
                {
                    XmlElement segmentElement = doc.CreateElement("segment");
                    segmentElement.AppendChild(doc.CreateTextNode(segment));
                    uriElement.AppendChild(segmentElement);
                }

                urlAddress.AppendChild(host);
                urlAddress.AppendChild(uriElement);
                if (!string.IsNullOrEmpty(uri.Query))
                {
                    XmlElement parameters = doc.CreateElement("parameters");
                    foreach (var parameterPair in GetParameters(uri.Query))
                    {
                        XmlElement parameter = doc.CreateElement("parametr");
                        XmlAttribute value = doc.CreateAttribute("value");
                        value.Value = parameterPair.Value;
                        XmlAttribute key = doc.CreateAttribute("key");
                        key.Value = parameterPair.Key;
                        parameter.Attributes.Append(value);
                        parameter.Attributes.Append(key);
                        parameters.AppendChild(parameter);
                    }

                    urlAddress.AppendChild(parameters);
                }

                root.AppendChild(urlAddress);
            }

            doc.AppendChild(root);
            doc.Save(destination);
        }

        private IEnumerable<Uri> GetUris(IEnumerable<string> uriStrings)
        {
            var list = new List<Uri>();
            foreach (var uriString in uriStrings)
            {
                try
                {
                    list.Add(new Uri(uriString));
                }
                catch (UriFormatException)
                {
                    this.logger.Log($"wrong uri: {uriString}");
                }
            }

            return list;
        }

        private IEnumerable<KeyValuePair<string, string>> GetParameters(string query)
        {
            query = query.Substring(1);
            var strPairs = query.Split('&');

            foreach (var str in strPairs)
            {
                var strPair = str.Split('=');
                var value = strPair[0];
                var key = strPair[1];
                yield return new KeyValuePair<string, string>(key, value);
            }
        }
    }
}
