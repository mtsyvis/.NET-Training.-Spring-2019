using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET1.S._2019.Tsyvis._01;

namespace MSTest.Test.Project
{
    [TestClass]
    public class ArrayExtensionMSUnitTests
    {
        private const int BigArraySize = 10000;

        #region Quick sort tests
        [TestMethod]
        public void QuickSort_RandomValueArray_WellSortedArray()
        {
            Random random = new Random();
            int[] expectedArray = new int[BigArraySize];
            int[] actualArray = new int[BigArraySize];

            for (int i = 0; i < expectedArray.Length; i++)
            {
                expectedArray[i] = random.Next();
            }

            Array.Copy(expectedArray, actualArray, expectedArray.Length);
            ArrayExtension.QuickSort(expectedArray);
            Array.Sort(actualArray);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [TestMethod]
        public void QuickSort_RandomValueArray_WellSortedArrayInRange()
        {
            Random random = new Random();
            int[] expectedArray = new int[BigArraySize];
            int[] actualArray = new int[BigArraySize];

            for (int i = 0; i < expectedArray.Length; i++)
            {
                expectedArray[i] = random.Next();
            }

            Array.Copy(expectedArray, actualArray, expectedArray.Length);
            ArrayExtension.QuickSort(expectedArray, BigArraySize / 3, BigArraySize / 2);
            Array.Sort(actualArray, BigArraySize / 3, BigArraySize / 2);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [TestMethod]
        public void QuickSort_ArrayIsNull_ThrowArgumentNullException()
        {
            int[] array = null;

            Assert.ThrowsException<ArgumentNullException>(() => ArrayExtension.QuickSort(array));
        }

        [TestMethod]
        public void QuickSort_ArrayLengthIsZero_ThrowArgumentException()
        {
            int[] array = new int[] { };

            Assert.ThrowsException<ArgumentException>(() => ArrayExtension.QuickSort(array));
            Assert.ThrowsException<ArgumentException>(() => ArrayExtension.QuickSort(array, 0, array.Length - 1));
        }

        [TestMethod]
        public void QuickSort_InsexIsLessThanLowerBoundOfArrayOrLengthIsLessThanZero_ThrowArgumentOutOfRangeException()
        {
            Random random = new Random();
            int[] array = new int[BigArraySize];

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ArrayExtension.QuickSort(array, -4, 50));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ArrayExtension.QuickSort(array, 20, -6));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ArrayExtension.QuickSort(array, BigArraySize, 10));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ArrayExtension.QuickSort(array, 10, BigArraySize));
        }
        #endregion

        #region Merge sort tests
        [TestMethod]
        public static void MergeSort_RandomValueArray_WellSortedArray()
        {
            Random random = new Random();
            int[] expectedArray = new int[BigArraySize];
            int[] actualArray = new int[BigArraySize];

            for (int i = 0; i < expectedArray.Length; i++)
            {
                expectedArray[i] = random.Next();
            }

            Array.Copy(expectedArray, actualArray, expectedArray.Length);
            ArrayExtension.MergeSort(expectedArray);
            Array.Sort(actualArray);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [TestMethod]
        public void MergeSort_RandomValueArray_WellSortedArrayInRange()
        {
            Random random = new Random();
            int[] expectedArray = new int[BigArraySize];
            int[] actualArray = new int[BigArraySize];

            for (int i = 0; i < expectedArray.Length; i++)
            {
                expectedArray[i] = random.Next();
            }

            Array.Copy(expectedArray, actualArray, expectedArray.Length);
            ArrayExtension.MergeSort(expectedArray, BigArraySize / 3, BigArraySize / 2);
            Array.Sort(actualArray, BigArraySize / 3, BigArraySize / 2);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [TestMethod]
        public void MergeSort_ArrayIsNull_ThrowArgumentNullException()
        {
            int[] array = null;

            Assert.ThrowsException<ArgumentNullException>(() => ArrayExtension.MergeSort(array));
        }

        [TestMethod]
        public void MergeSort_ArrayLengthIsZero_ThrowArgumentException()
        {
            int[] array = new int[] { };

            Assert.ThrowsException<ArgumentException>(() => ArrayExtension.MergeSort(array));
            Assert.ThrowsException<ArgumentException>(() => ArrayExtension.MergeSort(array, 0, array.Length - 1));
        }

        [TestMethod]
        public void MergeSort_InsexIsLessThanLowerBoundOfArrayOrLengthIsLessThanZero_ThrowArgumentOutOfRangeException()
        {
            Random random = new Random();
            int[] array = new int[BigArraySize];

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ArrayExtension.MergeSort(array, -4, 50));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ArrayExtension.MergeSort(array, 20, -6));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ArrayExtension.MergeSort(array, BigArraySize, 10));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ArrayExtension.MergeSort(array, 10, BigArraySize));
        }
        #endregion
    }
}
