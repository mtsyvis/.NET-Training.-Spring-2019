using System;

namespace WatchImitation
{
    /// <summary>
    /// Contain event date.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class TimeIsOverEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeIsOverEventArgs"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public TimeIsOverEventArgs(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }
    }
}
