using System;
using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._04
{
    /// <summary>
    /// Expands the possibilities of type double
    /// </summary>
    public static class DoubleExtension
    {
        /// <summary>
        /// Transform the real numbers to words.
        /// </summary>
        /// <param name="array">The array to transforming.</param>
        /// <returns>words</returns>
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

            List<string> words = new List<string>(array.Length);
            Transformer transformerNumber = new Transformer();

            foreach (var i in array)
            {
                words.Add(transformerNumber.TransformToWords(i));
            }

            return words.ToArray();
        }
    }
}
