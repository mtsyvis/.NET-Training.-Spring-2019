namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Defines method for logging.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        void Log(string text);
    }
}
