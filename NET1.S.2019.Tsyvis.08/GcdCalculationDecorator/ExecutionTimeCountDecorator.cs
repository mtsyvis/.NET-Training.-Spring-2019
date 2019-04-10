using NET1.S._2019.Tsyvis._08;
using System;

namespace GcdCalculationDecorator
{
    /// <summary>
    /// Provide calculate execution time of GCD algorithms.
    /// </summary>
    /// <seealso cref="GcdCalculationDecorator.GcdAlgorithmDecorator" />
    public class ExecutionTimeCountDecorator : GcdAlgorithmDecorator
    {
        /// <summary>
        /// The stop watcher
        /// </summary>
        private IStopwatcher stopwatcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionTimeCountDecorator"/> class.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        public ExecutionTimeCountDecorator(IGcdAlgorithm algorithm, IStopwatcher stopwatcher)
            : base(algorithm)
        {
            this.stopwatcher =
                stopwatcher ?? throw new ArgumentNullException($"stopwatcher is null{nameof(stopwatcher)}");
        }

        /// <summary>
        /// Gets the execution time.
        /// </summary>
        /// <value>
        /// The execution time.
        /// </value>
        public long ExecutionTime { get; private set; }

        /// <summary>
        /// Calculates the GCD and execution time.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>founded GCD</returns>
        public override int Calculate(int first, int second)
        {
            this.stopwatcher.Start();
            int gcd = this.algorithm.Calculate(first, second);
            this.stopwatcher.Stop();
            this.ExecutionTime = this.stopwatcher.TimeInMilliseconds;
            return gcd;
        }
    }
}