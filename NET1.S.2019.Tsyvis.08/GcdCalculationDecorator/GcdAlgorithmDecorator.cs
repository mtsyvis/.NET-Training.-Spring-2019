using System;
using NET1.S._2019.Tsyvis._08;

namespace GcdCalculationDecorator
{
    /// <summary>
    /// Implement IGcdAlgorithm.
    /// </summary>
    /// <seealso cref="NET1.S._2019.Tsyvis._08.IGcdAlgorithm" />
    public abstract class GcdAlgorithmDecorator : IGcdAlgorithm
    {
        /// <summary>
        /// The algorithm
        /// </summary>
        protected readonly IGcdAlgorithm algorithm;

        /// <summary>
        /// Initializes a new instance of the <see cref="GcdAlgorithmDecorator"/> class.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <exception cref="System.ArgumentNullException">algorithm is null{nameof(algorithm)}</exception>
        protected GcdAlgorithmDecorator(IGcdAlgorithm algorithm)
        {
            this.algorithm = algorithm ?? throw new ArgumentNullException($"algorithm is null{nameof(algorithm)}");
        }

        /// <summary>
        /// Calculates the GCD.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>GCD</returns>
        public abstract int Calculate(int first, int second);
    }
}
