using System;

namespace NET1.S._2019.Tsyvis._08
{
    /// <summary>
    /// Realizes finding gcd by the binary Euclidean (Stein) method.
    /// </summary>
    /// <seealso cref="NET1.S._2019.Tsyvis._08.IGcdAlgorithm" />
    public sealed class EuclideanGcdAlgorithm : IGcdAlgorithm
    {
        /// <summary>
        /// Find gcd for 2 numbers.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>
        /// founded gcd
        /// </returns>
        public int Calculate(int first, int second)
        {
            if (second == 0)
            {
                return Math.Abs(first);
            }

            return Calculate(second, first % second);
        }
    }
}
