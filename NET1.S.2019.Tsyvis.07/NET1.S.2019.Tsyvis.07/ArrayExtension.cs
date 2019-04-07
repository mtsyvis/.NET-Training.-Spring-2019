using System;
using System.Collections.Generic;
using NET1.S._2019.Tsyvis._07.Transform;
using NET1.S._2019.Tsyvis._07.Filter;
using NET1.S._2019.Tsyvis._07.Sort;

namespace NET1.S._2019.Tsyvis._07
{
    using NET1.S._2019.Tsyvis._07.Sort_jagged_array;

    /// <summary>
    /// Provide manipulation with array.
    /// </summary>
    public static class ArrayExtension
    {
        #region API

        /// <summary>
        /// Filters the array by selected <paramref name="predicate"/>.
        /// </summary>
        /// <param name="array">The array to filter.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>filtered array</returns>
        /// <exception cref="ArgumentNullException">predicate is null</exception>
        public static int[] Filter(this int[] array, IPredicateNumber predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException($"predicate is null{nameof(predicate)}");
            }

            var filteredNumbers = new List<int>();

            foreach (var i in array)
            {
                if (predicate.Condition(i))
                {
                    filteredNumbers.Add(i);
                }
            }

            return filteredNumbers.ToArray();
        }

        /// <summary>
        /// Transforms the array by selected rule.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="rule">The rule.</param>
        /// <returns>transformed array of strings</returns>
        /// <exception cref="ArgumentNullException">predicate is null</exception>
        public static string[] Transform(this double[] array, ITransformDoubleRule rule)
        {
            if (rule == null)
            {
                throw new ArgumentNullException($"predicate is null{nameof(rule)}");
            }

            var transformedNumbers = new List<string>();

            foreach (var i in array)
            {
                transformedNumbers.Add(rule.Transform(i));
            }

            return transformedNumbers.ToArray();
        }

        /// <summary>
        /// Sorts array by selected comparer.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="comparer">The comparer</param>
        /// <exception cref="ArgumentNullException">comparer is null</exception>
        public static void Sort(this string[] array, IComparer<string> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException($"comparer is null{nameof(comparer)}");
            }

            QuickSort(array, comparer);
        }

        /// <summary>
        /// Sorts the jagged array.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException">
        /// comparer is null
        /// or
        /// matrix has null elements
        /// </exception>
        public static void SortJaggedArray(this int[][] matrix, IComparer<int[]> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException($"comparer is null{nameof(comparer)}");
            }

            foreach (var i in matrix)
            {
                if (i == null)
                {
                    throw new ArgumentNullException($"matrix has null elements{nameof(i)}");
                }
            }

            Array.Sort(matrix, comparer);
        }

        #endregion

        #region Helper methods

        private static void QuickSort(string[] array, IComparer<string> comparer)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException($"array length is zero {nameof(array.Length)}");
            }

            QuickSortImplementation(array, 0, array.Length - 1, comparer);
        }

        private static void QuickSortImplementation(string[] array, int start, int end, IComparer<string> comparer)
        {
            if (start >= end)
            {
                return;
            }

            int pivot = Partition(array, start, end, comparer);
            QuickSortImplementation(array, start, pivot - 1, comparer);
            QuickSortImplementation(array, pivot + 1, end, comparer);
        }

        private static int Partition(string[] array, int start, int end, IComparer<string> comparer)
        {
            string temp;
            int marker = start;

            for (int i = start; i <= end; i++)
            {
                if (comparer.Compare(array[i], array[end]) > 0)
                {
                    temp = array[marker];
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }

            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }

        #endregion
    }
}
