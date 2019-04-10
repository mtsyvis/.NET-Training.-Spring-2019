using System;
using System.Diagnostics;

namespace GcdCalculationDecorator
{
    /// <summary>
    /// Provide calculating execution time.
    /// </summary>
    /// <seealso cref="GcdCalculationDecorator.IStopwatcher" />
    public class StopwatchAdapter : IStopwatcher
    {
        /// <summary>
        /// The stopwatch
        /// </summary>
        private Stopwatch stopwatch = new Stopwatch();

        /// <summary>
        /// Gets or sets the time in milliseconds.
        /// </summary>
        /// <value>
        /// The time in milliseconds.
        /// </value>
        public long TimeInMilliseconds { get; private set; }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            this.stopwatch.Start();
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            this.stopwatch.Stop();
            this.TimeInMilliseconds = this.stopwatch.ElapsedMilliseconds;
            this.stopwatch.Reset();
        }
    }
}
