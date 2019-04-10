using System;
using NET1.S._2019.Tsyvis._08;

namespace GcdCalculationDecorator
{
    /// <summary>
    /// Provide GCD calculation.
    /// </summary>
    public static class GCDCalculator
    {
        /// <summary>
        /// Calculates the specified algorithm.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>founded gcd</returns>
        /// <exception cref="ArgumentNullException">algorithm is null</exception>
        public static int Calculate(IGcdAlgorithm algorithm, int first, int second)
        {
            if (algorithm is null)
            {
                throw new ArgumentNullException($"algorithm is null{nameof(algorithm)}");
            }

            return algorithm.Calculate(first, second);
        }
    }
}