using NET1.S._2019.Tsyvis._08;

namespace GcdCalculationDecorator
{
    /// <summary>
    /// Provide calculate execution time of GCD algorithms.
    /// </summary>
    /// <seealso cref="GcdCalculationDecorator.GcdAlgorithmDecorator" />
    public class ExecutionTimeCountDecorator : GcdAlgorithmDecorator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionTimeCountDecorator"/> class.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        public ExecutionTimeCountDecorator(IGcdAlgorithm algorithm)
            : base(algorithm)
        {
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
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int gcd = this.algorithm.Calculate(first, second);
            watch.Stop();
            this.ExecutionTime = watch.ElapsedMilliseconds;
            return gcd;
        }
    }
}