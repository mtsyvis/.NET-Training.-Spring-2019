namespace NET1.S._2019.Tsyvis._22.Interfaces
{
    /// <summary>
    /// Defines methods to export.
    /// </summary>
    public interface IExportService
    {
        /// <summary>
        /// Exports the specified source path.
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <param name="destinationPath">The destination path.</param>
        void Export(string sourcePath, string destinationPath);
    }
}
