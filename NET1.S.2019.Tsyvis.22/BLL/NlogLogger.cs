using NLog;
using ILogger = BLL.Interface.Interfaces.ILogger;

namespace BLL
{
    /// <summary>
    /// Provide errors logging.
    /// </summary>
    /// <seealso cref="BLL.Interface.Interfaces.ILogger" />
    public class NLogLogger : ILogger
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Logs the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        public void Log(string text)
        {
            this.logger.Error(text);
        }
    }
}
