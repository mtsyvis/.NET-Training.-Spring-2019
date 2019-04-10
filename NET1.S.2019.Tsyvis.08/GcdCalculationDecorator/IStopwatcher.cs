namespace GcdCalculationDecorator
{
    /// <summary>
    /// Defines time performance calculation. 
    /// </summary>
    public interface IStopwatcher
    {
        /// <summary>
        /// Gets or sets the time in milliseconds.
        /// </summary>
        /// <value>
        /// The time in milliseconds.
        /// </value>
        long TimeInMilliseconds { get; }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops this instance.
        /// </summary>
        void Stop();
    }
}
