using System.Collections.Generic;
using System.IO;
using NET1.S._2019.Tsyvis._22.Interfaces;

namespace BLL
{
    /// <summary>
    /// Provide uri reading.
    /// </summary>
    /// <seealso cref="NET1.S._2019.Tsyvis._22.Interfaces.IUriReader" />
    public class UriLineReader : IUriReader
    {
        /// <summary>
        /// Reads the uris.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>
        /// uris
        /// </returns>
        public IEnumerable<string> ReadUris(string filePath)
        {
            return File.ReadAllLines(filePath);
        }
    }
}
