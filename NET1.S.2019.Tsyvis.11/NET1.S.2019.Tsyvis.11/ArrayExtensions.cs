using System;
using System.Collections.Generic;

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

            return BinarySearchImplementation(array, 0, array.Length, value, Comparer<T>.Default);
        }

        /// <summary>
        /// Binaries the search.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array</typeparam>
        /// <param name="array">The array.</param>
        /// <param name="value">The value.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>The index of the specified value in the specified array,
        /// if value is found; otherwise, a negative number.
        /// </returns>
        public static int BinarySearch<T>(this T[] array, T value, IComparer<T> comparer)
            where T : IComparable<T>
        {
            if (array.Length == 0)
            {
                return -1;
            }

            if (comparer == null)
            {
                comparer = Comparer<T>.Default;
            }

            return BinarySearchImplementation(array, 0, array.Length, value, comparer);
        }

        /// <summary>
        /// Binaries the search.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array</typeparam>
        /// <param name="array">The array.</param>
        /// <param name="index">The index.</param>
        /// <param name="length">The length.</param>
        /// <param name="value">The value.</param>
        /// <returns>The index of the specified value in the specified array,
        /// if value is found; otherwise, a negative number.</returns>
        /// <exception cref="ArgumentOutOfRangeException">index or length less are negative</exception>
        /// <exception cref="ArgumentException">argument invalid</exception>
        public static int BinarySearch<T>(this T[] array, int index, int length, T value)
            where T : IComparable<T>
        {
            if (index < 0 || length < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(index)} < 0 or {nameof(length)} < 0");
            }

            if (array.Length - index < length)
            {
                throw new ArgumentException($"argument invalid");
            }

            if (array.Length == 0)
            {
                return -1;
            }

            return BinarySearchImplementation(array, index, index + length + 1, value, Comparer<T>.Default);
        }

        /// <summary>
        /// Binaries the search.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array</typeparam>
        /// <param name="array">The array.</param>
        /// <param name="index">The index.</param>
        /// <param name="length">The length.</param>
        /// <param name="value">The value.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>The index of the specified value in the specified array,
        /// if value is found; otherwise, a negative number.</returns>
        /// <exception cref="ArgumentOutOfRangeException">index or length less are negative</exception>
        /// <exception cref="ArgumentException">argument invalid</exception>
        public static int BinarySearch<T>(this T[] array, int index, int length, T value, IComparer<T> comparer)
            where T : IComparable<T>
        {
            if (index < 0 || length < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(index)} < 0 or {nameof(length)} < 0");
            }

            if (array.Length - index < length)
            {
                throw new ArgumentException($"argument invalid");
            }

            if (array.Length == 0)
            {
                return -1;
            }

            if (comparer == null)
            {
                comparer = Comparer<T>.Default;
            }

            return BinarySearchImplementation(array, index, index + length + 1, value, comparer);
        }

        private static int BinarySearchImplementation<T>(T[] array, int left, int right, T value, IComparer<T> comparer)
            where T : IComparable<T>
        {
            int middle = left + (right - left) / 2;

            if (left >= right)
            {
                return -1;
            }

            if (comparer.Compare(array[middle], value) == 0)
            {
                return middle;
            }

            if (comparer.Compare(array[middle], value) > 0)
            {
                return BinarySearchImplementation<T>(array, left, middle, value, comparer);
            }
            else
            {
                return BinarySearchImplementation<T>(array, middle + 1, right, value, comparer);
            }
        }
    }
}
