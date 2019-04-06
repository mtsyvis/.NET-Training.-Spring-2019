using System;

namespace NET1.S._2019.Tsyvis._08
{
    /// <summary>
    /// Realizes finding gcd by the binary Euclidean (Stein) method.
    /// </summary>
    /// <seealso cref="NET1.S._2019.Tsyvis._08.IGcdAlgorithm" />
    public sealed class BinaryGcdAlgorithm : IGcdAlgorithm
    {
        /// <summary>
        /// Find gcd for 2 numbers.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>
        /// found gcded
        /// </returns>
        public int Calculate(int first, int second)
        {
            first = Math.Abs(first);
            second = Math.Abs(second);

            int gcd = 1;
            int tmp = 0;
            if (first == second)
            {
                return first;
            }
            if (first == 1 || second == 1)
            {
                return 1;
            }

            while (first != 0 && second != 0)
            {
                if (first % 2 == 0 && second % 2 == 0)
                {
                    gcd *= 2;
                    first /= 2;
                    second /= 2;
                    continue;
                }
                if (first % 2 == 0 && second % 2 != 0)
                {
                    first /= 2;
                    continue;
                }
                if (second % 2 == 0 && first % 2 != 0)
                {
                    second /= 2;
                    continue;
                }
                if (first > second)
                {
                    tmp = first;
                    first = second;
                    second = tmp;
                }
                tmp = first;
                first = (second - first) / 2;
                second = tmp;
            }

            if (first == 0)
            {
                return gcd * second;
            }
            else
            {
                return gcd * first;
            }
        }
    }
}
