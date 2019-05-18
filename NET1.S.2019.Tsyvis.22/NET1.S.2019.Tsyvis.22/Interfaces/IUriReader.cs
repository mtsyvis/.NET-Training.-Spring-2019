using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._22.Interfaces
{
    /// <summary>
    /// Defines the uri reading method.
    /// </summary>
    public interface IUriReader
    {
        /// <summary>
        /// Reads the uris.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>uris</returns>
        IEnumerable<string> ReadUris(string filePath);
    }
}
