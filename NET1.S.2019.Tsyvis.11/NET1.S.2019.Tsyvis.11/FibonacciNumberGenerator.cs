using System;

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
        public static int[] GenerateNumberSequences(int sequenceSize)
        {
            if (sequenceSize < 2)
            {
                throw new ArgumentException($"sequence size must be more then 2{nameof(sequenceSize)}");
            }

            int[] array = new int[sequenceSize];
            array[0] = 0;
            array[1] = 1;

            for (int i = 2; i < array.Length; i++)
            {
                array[i] = array[i - 1] + array[i - 2];
            }

            return array;
        }
    }
}
