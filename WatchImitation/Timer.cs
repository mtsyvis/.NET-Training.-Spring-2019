using System;
using System.Threading;

namespace WatchImitation
{
    /// <summary>
    /// Provide timer logic
    /// </summary>
    public class Timer
    {
        private readonly string message = "Time is over";

        private int stopTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="Timer"/> class.
        /// </summary>
        /// <param name="stopTime">The stop time.</param>
        public Timer(int stopTime)
        {
            this.stopTime = stopTime;
        }

        /// <summary>
        /// Occurs when [timer has stopped].
        /// </summary>
        public event EventHandler<TimeIsOverEventArgs> TimerHasStopped = delegate { };

        /// <summary>
        /// Gets or sets the stop time.
        /// </summary>
        /// <value>
        /// The stop time.
        /// </value>
        /// <exception cref="System.ArgumentOutOfRangeException">time can't be less then 0</exception>
        public int StopTime
        {
            get => this.stopTime;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"time can't be less then 0");
                }

                this.stopTime = value;
            }
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            Thread.Sleep(1000 * StopTime);
            this.OnTimerHasStopped();
        }

        /// <summary>
        /// Called when [timer has stopped].
        /// </summary>
        private void OnTimerHasStopped()
        {
            var local = TimerHasStopped;
            local?.Invoke(this, new TimeIsOverEventArgs(this.message));
        }
    }
}
