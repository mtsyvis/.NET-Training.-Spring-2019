using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET1.S._2019.Tsyvis._01
{
    /// <summary>
    /// Class ArrayExtension
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Sorts the elements in one-dimensional integer array using a quicksort algorithm.
        /// </summary>
        /// <param name="array">The one-dimensional integer array to sort.</param>
        /// <param name="start">The starting index of the range to sort.</param>
        /// <param name="length">The number of elements in the range to sort.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void QuickSort(int[] array, int start, int length)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            if (start < 0 || length < 0 || start + length > array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            QuickSortImplementation(array, start, start + length - 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
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

        //public static void MergeSort(int[] input, int low, int high)
        //{
        //    if (low < high)
        //    {
        //        int middle = (low / 2) + (high / 2);
        //        MergeSort(input, low, middle);
        //        MergeSort(input, middle + 1, high);
        //        Merge(input, low, middle, high);
        //    }
        //}

        //public static void MergeSort(int[] input)
        //{
        //    MergeSort(input, 0, input.Length - 1);
        //}

        //private static void Merge(int[] input, int low, int middle, int high)
        //{

        //    int left = low;
        //    int right = middle + 1;
        //    int[] tmp = new int[(high - low) + 1];
        //    int tmpIndex = 0;

        //    while ((left <= middle) && (right <= high))
        //    {
        //        if (input[left] < input[right])
        //        {
        //            tmp[tmpIndex] = input[left];
        //            left = left + 1;
        //        }
        //        else
        //        {
        //            tmp[tmpIndex] = input[right];
        //            right = right + 1;
        //        }
        //        tmpIndex = tmpIndex + 1;
        //    }

        //    if (left <= middle)
        //    {
        //        while (left <= middle)
        //        {
        //            tmp[tmpIndex] = input[left];
        //            left = left + 1;
        //            tmpIndex = tmpIndex + 1;
        //        }
        //    }

        //    if (right <= high)
        //    {
        //        while (right <= high)
        //        {
        //            tmp[tmpIndex] = input[right];
        //            right = right + 1;
        //            tmpIndex = tmpIndex + 1;
        //        }
        //    }

        //    for (int i = 0; i < tmp.Length; i++)
        //    {
        //        input[low + i] = tmp[i];
        //    }

        //}

    }
}
