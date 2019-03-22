using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET1.S._2019.Tsyvis._02
{
    /// <summary>
    /// Provide methots for searching max value in array.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Find max value in a one-dimensional integer array by recursive invoke.
        /// </summary>
        /// <param name="array">The one-dimensional integer array to search.</param>
        /// <returns>The max value in the one-dimensional integer array</returns>
        /// <exception cref="ArgumentNullException">array is null.</exception>
        /// <exception cref="ArgumentException">length of array is 0.</exception>
        public static int FindMaxValue(int[] array)
        {
            if(array == null)
            {
                throw new ArgumentNullException($"Array is null {nameof(array)}");
            }

            if(array.Length == 0)
            {
                throw new ArgumentException($"Length of array is 0 {nameof(array.Length)}");
            }

            return FindMaxValueRecursive(array, array.Length);
        }

        private static int FindMaxValueRecursive(int[] A, int n)
        {
            if (n == 1)
            {
                return A[0];
            }

            return Math.Max(A[n - 1], FindMaxValueRecursive(A, n - 1));
        }
    }
}
