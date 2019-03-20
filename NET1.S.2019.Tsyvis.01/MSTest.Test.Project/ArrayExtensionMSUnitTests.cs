using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET1.S._2019.Tsyvis._01;

namespace MSTest.Test.Project
{
    [TestClass]
    public class ArrayExtensionMSUnitTests
    {
        private const int BigArraySize = 10000;

        [TestMethod]
        public void QuickSort_RandomValueArray_WellSortedArray()
        {
            // Arrange
            Random random = new Random();

            int[] expectedArray = new int[BigArraySize];
            int[] actualArray = new int[BigArraySize];

            for (int i = 0; i < expectedArray.Length; i++)
            {
                expectedArray[i] = random.Next();
            }

            Array.Copy(expectedArray, actualArray, expectedArray.Length);

            // Act
            ArrayExtension.QuickSort(expectedArray);
            Array.Sort(actualArray);

            // Assert
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [TestMethod]
        public void QuickSort_RandomValueArray_WellSortedArrayInRange()
        {
            // Arrange
            Random random = new Random();

            int[] expectedArray = new int[BigArraySize];
            int[] actualArray = new int[BigArraySize];

            for (int i = 0; i < expectedArray.Length; i++)
            {
                expectedArray[i] = random.Next();
            }

            Array.Copy(expectedArray, actualArray, expectedArray.Length);

            // Act
            ArrayExtension.QuickSort(expectedArray, BigArraySize / 3, BigArraySize / 2);
            Array.Sort(actualArray, BigArraySize / 3, BigArraySize / 2);

            // Assert
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [TestMethod]
        public static void MergeSort_RandomValueArray_WellSortedArray()
        {
            // Arrange
            Random random = new Random();

            int[] expectedArray = new int[BigArraySize];
            int[] actualArray = new int[BigArraySize];

            for (int i = 0; i < expectedArray.Length; i++)
            {
                expectedArray[i] = random.Next();
            }

            Array.Copy(expectedArray, actualArray, expectedArray.Length);

            // Act
            ArrayExtension.MergeSort(expectedArray);
            Array.Sort(actualArray);

            // Assert
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [TestMethod]
        public void MergeSort_RandomValueArray_WellSortedArrayInRange()
        {
            // Arrange
            Random random = new Random();

            int[] expectedArray = new int[BigArraySize];
            int[] actualArray = new int[BigArraySize];

            for (int i = 0; i < expectedArray.Length; i++)
            {
                expectedArray[i] = random.Next();
            }

            Array.Copy(expectedArray, actualArray, expectedArray.Length);

            // Act
            ArrayExtension.MergeSort(expectedArray, BigArraySize / 3, BigArraySize / 2);
            Array.Sort(actualArray, BigArraySize / 3, BigArraySize / 2);

            // Assert
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [TestMethod]
        public void QuickSortAndMergeSort_ArrayIsNull_ThrowArgumentNullException()
        {
            // Arrange
            int[] array = null;

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => ArrayExtension.QuickSort(array));
            Assert.ThrowsException<ArgumentNullException>(() => ArrayExtension.MergeSort(array));
        }

        [TestMethod]
        public void QuickSortAndMergeSort_ArrayLengthIsZero_ThrowArgumentException()
        {
            // Arrange
            int[] array = new int[] { };

            // Assert
            Assert.ThrowsException<ArgumentException>(() => ArrayExtension.QuickSort(array));
            Assert.ThrowsException<ArgumentException>(() => ArrayExtension.MergeSort(array));
            Assert.ThrowsException<ArgumentException>(() => ArrayExtension.QuickSort(array, 0, array.Length - 1));
            Assert.ThrowsException<ArgumentException>(() => ArrayExtension.MergeSort(array, 0, array.Length - 1));
        }

        [TestMethod]
        public void QuickSortAndMergeSort_InsexIsLessThanLowerBoundOfArrayOrLengthIsLessThanZero_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            Random random = new Random();

            int[] array = new int[BigArraySize];

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ArrayExtension.QuickSort(array, -4, 50));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ArrayExtension.MergeSort(array, -4, 50));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ArrayExtension.QuickSort(array, 20, -6));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ArrayExtension.MergeSort(array, 20, -6));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ArrayExtension.QuickSort(array, BigArraySize, 10));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ArrayExtension.MergeSort(array, BigArraySize, 10));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ArrayExtension.QuickSort(array, 10, BigArraySize));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ArrayExtension.MergeSort(array, 10, BigArraySize));
        }
    }
}
