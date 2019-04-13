using System;

namespace NET1.S._2019.Tsyvis._11
{
    /// <summary>
    /// Provides a binary search for elements in an array
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Binaries the search.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.
        /// </typeparam>
        /// <param name="array">The array.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The index of the specified value in the specified array,
        /// if value is found; otherwise, a negative number.
        /// </returns>
        public static int BinarySearch<T>(this T[] array, T value)
            where T : IComparable<T>
        {
            if (array.Length == 0)
            {
                return -1;
            }

            bool descendingOrder = array[0].CompareTo(array[array.Length - 1]) > 0;

            return BinarySearchImplementation(array, descendingOrder, 0, array.Length, value);
        }

        private static int BinarySearchImplementation<T>(T[] array, bool descendingOrder, int left, int right, T value)
            where T : IComparable<T>
        {
            int middle = left + (right - left) / 2;

            if (left >= right)
            {
                return -1;
            }

            if (array[middle].Equals(value))
            {
                return middle;
            }

            if ((array[middle].CompareTo(value) > 0) ^ descendingOrder)
            {
                return BinarySearchImplementation<T>(array, descendingOrder, left, middle, value);
            }
            else
            {
                return BinarySearchImplementation<T>(array, descendingOrder, middle + 1, right, value);
            }
        }
    }
}
