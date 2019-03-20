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
    }
}
