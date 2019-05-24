using NLog;
using ILogger = DAL.Interface.Interfaces.ILogger;

namespace BLL.ServiceImplementation
{
    /// <summary>
    /// Provide logging using NLog
    /// </summary>
    /// <seealso cref="DAL.Interface.Interfaces.ILogger" />
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
