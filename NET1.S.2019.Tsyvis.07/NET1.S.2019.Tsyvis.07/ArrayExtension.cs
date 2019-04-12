using System;
using System.Collections.Generic;
using NET1.S._2019.Tsyvis._07.Transform;
using NET1.S._2019.Tsyvis._07.Filter;

namespace NET1.S._2019.Tsyvis._07
{
    /// <summary>
    /// Provide manipulation with array.
    /// </summary>
    public static class ArrayExtension
    {
        #region API

        /// <summary>
        /// Filters the specified predicate.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="array">The array.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Sorted array</returns>
        /// <exception cref="ArgumentNullException">predicate is null</exception>
        public static TSource[] Filter<TSource>(this TSource[] array, IPredicateNumber<TSource> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException($"predicate is null{nameof(predicate)}");
            }

            var filteredNumbers = new List<TSource>();

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
        public static TResult[] Transform<TResult, TSource>(this TSource[] array, ITransform<TResult, TSource> rule)
        {
            if (rule == null)
            {
                throw new ArgumentNullException($"predicate is null{nameof(rule)}");
            }

            var transformedNumbers = new List<TResult>();

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
        public static TSource[] Sort<TSource>(this TSource[] array, IComparer<TSource> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException($"comparer is null{nameof(comparer)}");
            }

            var copyArray = new TSource[array.Length];
            Array.Copy(array, copyArray, array.Length);
            QuickSort(copyArray, comparer);

            return copyArray;
        }

        /// <summary>
        /// Sorts the jagged array.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>sorted array</returns>
        /// <exception cref="ArgumentNullException">
        /// comparer is null
        /// </exception>
        public static int[][] SortJaggedArray(this int[][] array, IComparer<int[]> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException($"comparer is null{nameof(comparer)}");
            }

            var copyArray = GetCopyJuggedArray(array);

            Array.Sort(copyArray, comparer);

            return copyArray;
        }

        #endregion

        #region Helper methods

        private static int[][] GetCopyJuggedArray(int[][] source)
        {
            var copyArray = new int[source.Length][];

            for (int i = 0; i < source.Length; i++)
            {
                copyArray[i] = (int[])source[i].Clone();
            }

            return copyArray;
        }

        private static void QuickSort<TSource>(TSource[] array, IComparer<TSource> comparer)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException($"array length is zero {nameof(array.Length)}");
            }

            QuickSortImplementation(array, 0, array.Length - 1, comparer);
        }

        private static void QuickSortImplementation<TSource>(TSource[] array, int start, int end, IComparer<TSource> comparer)
        {
            if (start >= end)
            {
                return;
            }

            int pivot = Partition(array, start, end, comparer);
            QuickSortImplementation(array, start, pivot - 1, comparer);
            QuickSortImplementation(array, pivot + 1, end, comparer);
        }

        private static int Partition<TSource>(TSource[] array, int start, int end, IComparer<TSource> comparer)
        {
            TSource temp;
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
