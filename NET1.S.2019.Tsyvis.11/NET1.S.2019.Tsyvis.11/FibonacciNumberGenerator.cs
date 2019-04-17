using System;
using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._11
{
    /// <summary>
    /// Provide generating number sequences.
    /// </summary>
    public static class FibonacciNumberGenerator
    {
        /// <summary>
        /// Generates the number sequences.
        /// </summary>
        /// <param name="sequenceSize">Size of the sequence.</param>
        /// <returns>generated sequences</returns>
        /// <exception cref="System.ArgumentException">sequence size must be more then 2</exception>
        public static IEnumerable<ulong> GenerateNumberSequences(int sequenceSize)
        {
            if (sequenceSize < 2)
            {
                throw new ArgumentException($"sequence size must be more then 2{nameof(sequenceSize)}");
            }

            return GetSequence(sequenceSize);
        }

        private static IEnumerable<ulong> GetSequence(int sequenceSize)
        {
            ulong fib1 = 0;
            ulong fib2 = 1;
            yield return fib1;
            yield return fib2;

            while (--sequenceSize != 1)
            {
                ulong fib3 = fib1 + fib2;
                yield return fib3;
                fib1 = fib2;
                fib2 = fib3;
            }
        }
    }
}
