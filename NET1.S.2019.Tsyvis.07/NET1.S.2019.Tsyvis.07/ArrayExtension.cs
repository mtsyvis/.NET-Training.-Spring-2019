﻿using System;
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
        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> array, IPredicateNumber<TSource> predicate) where TSource : struct
        {
            if (predicate == null)
            {
                yield break;
            }

            foreach (var i in array)
            {
                if (predicate.Condition(i))
                {
                    yield return i;
                }
            }
        }

        /// <summary>
        /// Transforms the specified rule.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="array">The array.</param>
        /// <param name="rule">The rule.</param>
        /// <returns>Transformed collection</returns>
        /// <exception cref="ArgumentNullException">rule is null</exception>
        public static IEnumerable<TResult> Transform<TResult, TSource>(this IEnumerable<TSource> array, ITransform<TResult, TSource> rule)
        {
            if (rule == null)
            {
                throw new ArgumentNullException($"rule is null{nameof(rule)}");
            }

            var transformedNumbers = new List<TResult>();

            foreach (var i in array)
            {
                transformedNumbers.Add(rule.Transform(i));
            }

            return TransformIterator(transformedNumbers);
        }

        /// <summary>
        /// Sorts the by.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="array">The array.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>sorted array</returns>
        /// <exception cref="ArgumentNullException">comparer is null</exception>
        public static IEnumerable<TSource> SortBy<TSource>(this IEnumerable<TSource> array, IComparer<TSource> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException($"comparer is null{nameof(comparer)}");
            }

            var copyArray = array.ToArray();
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

        private static TElement[] ToArray<TElement>(this IEnumerable<TElement> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)}");
            }

            TElement[] array = null;

            if (source is ICollection<TElement> elements)
            {
                array = new TElement[elements.Count];
                elements.CopyTo(array, 0);
                return array;
            }
            else
            {
                var tempArray = new TElement[source.Count()];
                int i = 0;
                foreach (var element in source)
                {
                    tempArray[i] = element;
                    i++;
                }

                array = new TElement[source.Count()];
                Array.Copy(tempArray, array, tempArray.Length);
                return array;
            }
        }

        private static int Count<TSource>(this IEnumerable<TSource> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)}");
            }

            int count = 0;
            while (source.GetEnumerator().MoveNext())
            {
                count++;
            }

            return count;
        }
        
        private static int[][] GetCopyJuggedArray(int[][] source)
        {
            var copyArray = new int[source.Length][];

            for (int i = 0; i < source.Length; i++)
            {
                copyArray[i] = (int[])source[i].Clone();
            }

            return copyArray;
        }

        private static IEnumerable<TResult> TransformIterator<TResult>(IEnumerable<TResult> collection)
        {
            foreach (var item in collection)
            {
                yield return item;
            }
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
