using System;

namespace NET1.S._2019.Tsyvis._01
{
    /// <summary>
    /// Class ArrayExtension
    /// </summary>
    public static class ArrayExtension
    {
        #region Quick sort API
        /// <summary>
        /// Sorts the elements in a range of elements in a one-dimensional integer array using a quicksort algorithm.
        /// </summary>
        /// <param name="array">The one-dimensional integer array to sort.</param>
        /// <param name="index">The starting index of the range to sort.</param>
        /// <param name="length">The number of elements in the range to sort.</param>
        /// <exception cref="ArgumentNullException">array is null</exception>
        /// <exception cref="ArgumentException">array length is zero</exception>
        /// <exception cref="ArgumentOutOfRangeException">index is less than the lower bound of array. -or- length is less than zero.</exception>
        public static void QuickSort(int[] array, int index, int length)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            if (index < 0 || length < 0 || index + length > array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            QuickSortImplementation(array, index, index + length - 1);
        }

        /// <summary>
        /// Sorts the elements in one-dimensional integer array using a quicksort algorithm.
        /// </summary>
        /// <param name="array">The one-dimensional integer array to sort.</param>
        /// <exception cref="ArgumentNullException">array is null</exception>
        /// <exception cref="ArgumentException">array length is zero</exception>
        public static void QuickSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            QuickSortImplementation(array, 0, array.Length - 1);
        }
        #endregion

        #region Merge sort API
        /// <summary>
        /// Sorts the elements in one-dimensional integer array using a sort by merge algorithm.
        /// </summary>
        /// <param name="array">The one-dimensional integer array to sort.</param>
        /// <exception cref="ArgumentNullException">array is null</exception>
        /// <exception cref="ArgumentException">array length is zero</exception>
        public static void MergeSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            MergeSortImplementation(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Sorts the elements in a range of elements in a one-dimensional integer array using a sort by merge algorithm.
        /// </summary>
        /// <param name="array">The one-dimensional integer array to sort.</param>
        /// <param name="index">The starting index of the range to sort.</param>
        /// <param name="length">The number of elements in the range to sort.</param>
        /// <exception cref="ArgumentNullException">array is null</exception>
        /// <exception cref="ArgumentException">array length is zero</exception>
        /// <exception cref="ArgumentOutOfRangeException">index is less than the lower bound of array. -or- length is less than zero.</exception>
        public static void MergeSort(int[] array, int index, int length)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            if (index < 0 || length < 0 || index + length > array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            MergeSortImplementation(array, index, index + length - 1);
        }
        #endregion

        #region Private methods quick sort
        private static void QuickSortImplementation(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pivot = Partition(array, start, end);
            QuickSortImplementation(array, start, pivot - 1);
            QuickSortImplementation(array, pivot + 1, end);
        }

        private static int Partition(int[] array, int start, int end)
        {
            int temp;
            int marker = start;

            for (int i = start; i <= end; i++)
            {
                if (array[i] < array[end])
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

        #region Private methods merge sort
        private static void MergeSortImplementation(int[] input, int low, int high)
        {
            if (low < high)
            {
                int middle = (low / 2) + (high / 2);
                MergeSortImplementation(input, low, middle);
                MergeSortImplementation(input, middle + 1, high);
                Merge(input, low, middle, high);
            }
        }

        private static void Merge(int[] input, int low, int middle, int high)
        {
            int left = low;
            int right = middle + 1;
            int[] tmp = new int[(high - low) + 1];
            int tmpIndex = 0;

            while ((left <= middle) && (right <= high))
            {
                if (input[left] < input[right])
                {
                    tmp[tmpIndex] = input[left];
                    left = left + 1;
                }
                else
                {
                    tmp[tmpIndex] = input[right];
                    right = right + 1;
                }

                tmpIndex = tmpIndex + 1;
            }

            if (left <= middle)
            {
                while (left <= middle)
                {
                    tmp[tmpIndex] = input[left];
                    left = left + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            if (right <= high)
            {
                while (right <= high)
                {
                    tmp[tmpIndex] = input[right];
                    right = right + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            for (int i = 0; i < tmp.Length; i++)
            {
                input[low + i] = tmp[i];
            }
        }
        #endregion
    }
}
