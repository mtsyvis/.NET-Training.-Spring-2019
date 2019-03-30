using System;
using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._04
{
    /// <summary>
    /// Expands the possibilities of type double.
    /// </summary>
    public static class DoubleExtension
    {
        /// <summary>
        /// Transform the real numbers to words.
        /// </summary>
        /// <param name="array">The array to transforming.</param>
        /// <returns>string array from the verbal representation of a number</returns>
        /// <exception cref="System.ArgumentNullException">array is null</exception>
        /// <exception cref="System.ArgumentException">length of array is 0</exception>
        public static string[] Transform(this double[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} array is null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array.Length)} length of array is 0");
            }

            var words = new List<string>(array.Length);
            var transformerNumber = new Transformer();

            foreach (var i in array)
            {
                words.Add(transformerNumber.TransformToWords(i));
            }

            return words.ToArray();
        }

        /// <summary>
        /// Transforms a real number to binary string representation.
        /// </summary>
        /// <param name="number">The real number.</param>
        /// <returns>string representation of a real number</returns>
        public static string TransformToBinary(this double number)
        {
            long bits = BitConverter.DoubleToInt64Bits(number);
            return Convert.ToString(bits, 2).PadLeft(64, '0');
        }
    }
}
