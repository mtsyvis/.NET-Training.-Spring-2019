using System;
using NET1.S._2019.Tsyvis._08;

namespace GcdCalculationDecorator
{
    /// <summary>
    /// Provide GCD calculation.
    /// </summary>
    public static class GCDCalculation
    {
        /// <summary>
        /// Calculates the GCD by euclidean algorithm returned execution time.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="time">The time.</param>
        /// <returns>founded GCD</returns>
        public static int CalculateGcdByEuclideanAndTime(int a, int b, out long time)
        {
            var calculator = new ExecutionTimeCountDecorator(new EuclideanGcdAlgorithm());
            int gcd = calculator.Calculate(a, b);
            time = calculator.ExecutionTime;
            return gcd;
        }

        /// <summary>
        /// Calculates the GCD by stain algorithm returned execution time.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="time">The time.</param>
        /// <returns>founded GCD</returns>
        public static int CalculateGcdByStainAndTime(int a, int b, out long time)
        {
            var calculator = new ExecutionTimeCountDecorator(new BinaryGcdAlgorithm());
            int gcd = calculator.Calculate(a, b);
            time = calculator.ExecutionTime;
            return gcd;
        }
    }
}