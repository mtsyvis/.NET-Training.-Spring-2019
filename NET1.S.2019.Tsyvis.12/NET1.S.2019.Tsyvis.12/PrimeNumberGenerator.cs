using System;
using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._12
{
    /// <summary>
    /// Provide generating prime numbers.
    /// </summary>
    public static class PrimeNumberGenerator
    {
        /// <summary>
        /// Gets the sequence.
        /// </summary>
        /// <param name="stopNumber">The stop number.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">stop number can't be less then 0</exception>
        public static IEnumerable<long> GetSequence(long stopNumber)
        {
            if (stopNumber < 0)
            {
                throw new ArgumentOutOfRangeException($"stop number can't be less then 0 {nameof(stopNumber)}");
            }

            return SieveOfEratosthenes(stopNumber);
        }

        private static IEnumerable<long> SieveOfEratosthenes(long stopNumber)
        {
            var prime = new bool[stopNumber + 1];

            for (long i = 0; i < stopNumber; i++)
            {
                prime[i] = true;
            }

            for (int p = 2; p * p <= stopNumber; p++)
            {
                if (prime[p] == true)
                {
                    for (int i = p * p; i <= stopNumber; i += p)
                    {
                        prime[i] = false;
                    }
                }
            }

            for (long i = 2; i <= stopNumber; i++)
            {
                if (prime[i] == true)
                {
                    yield return i;
                }
            }
        }
    }
}
