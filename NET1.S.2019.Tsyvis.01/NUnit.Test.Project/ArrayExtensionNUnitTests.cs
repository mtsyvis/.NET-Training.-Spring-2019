using NUnit.Framework;
using System;
using NET1.S._2019.Tsyvis._01;

namespace NUnit.Test.Project
{
    [TestFixture]
    public class ArrayExtensionNUnitTests
    {
        private const int BigArraySize = 10000;

        #region Quick sort tests
        [Test]
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

        [Test]
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

        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { 1, 6, 4 }, new int[] { 1, 4, 6 })]
        [TestCase(new int[] { 10, -5, 7, 4 }, new int[] { -5, 4, 7, 10 })]
        [TestCase(new int[] { int.MinValue, -1, -6, -4, -100 }, new int[] { int.MinValue, -100, -6, -4, -1 })]
        [TestCase(new int[] { 1000, 100, 250, int.MaxValue }, new int[] { 100, 250, 1000, int.MaxValue })]
        [TestCase(new int[] { 10, 10, 5, 5, 8, -1, -1, 0 }, new int[] { -1, -1, 0, 5, 5, 8, 10, 10 })]
        public void QuickSort_ArrayFromTestCases_WellSorted(int[] arrayActual, int[] arrayExpected)
        {
            ArrayExtension.QuickSort(arrayActual);

            CollectionAssert.AreEqual(arrayActual, arrayExpected);
        }

        [Test]
        public void QuickSort_ArrayIsNull_ThrowArgumentNullException()
        {
            int[] array = null;

            Assert.Throws<ArgumentNullException>(() => ArrayExtension.QuickSort(array));
        }

        [Test]
        public void QuickSort_ArrayLengthIsZero_ThrowArgumentException()
        {
            int[] array = new int[] { };

            Assert.Throws<ArgumentException>(() => ArrayExtension.QuickSort(array));
            Assert.Throws<ArgumentException>(() => ArrayExtension.QuickSort(array, 0, array.Length - 1));
        }

        [Test]
        public void QuickSort_InsexIsLessThanLowerBoundOfArrayOrLengthIsLessThanZero_ThrowArgumentOutOfRangeException()
        {
            Random random = new Random();
            int[] array = new int[BigArraySize];

            Assert.Throws<ArgumentOutOfRangeException>(() => ArrayExtension.QuickSort(array, -4, 50));
            Assert.Throws<ArgumentOutOfRangeException>(() => ArrayExtension.QuickSort(array, 20, -6));
            Assert.Throws<ArgumentOutOfRangeException>(() => ArrayExtension.QuickSort(array, BigArraySize, 10));
            Assert.Throws<ArgumentOutOfRangeException>(() => ArrayExtension.QuickSort(array, 10, BigArraySize));
        }
        #endregion

        #region Merge sort tests
        [Test]
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

        [Test]
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

        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { 1, 6, 4 }, new int[] { 1, 4, 6 })]
        [TestCase(new int[] { 10, -5, 7, 4 }, new int[] { -5, 4, 7, 10 })]
        [TestCase(new int[] { int.MinValue, -1, -6, -4, -100 }, new int[] { int.MinValue, -100, -6, -4, -1 })]
        [TestCase(new int[] { 1000, 100, 250, int.MaxValue }, new int[] { 100, 250, 1000, int.MaxValue })]
        [TestCase(new int[] { 10, 10, 5, 5, 8, -1, -1, 0 }, new int[] { -1, -1, 0, 5, 5, 8, 10, 10 })]
        public void MergeSort_ArrayFromTestCases_WellSorted(int[] arrayActual, int[] arrayExpected)
        {
            ArrayExtension.MergeSort(arrayActual);

            CollectionAssert.AreEqual(arrayActual, arrayExpected);
        }

        [Test]
        public void MergeSort_ArrayIsNull_ThrowArgumentNullException()
        {
            int[] array = null;

            Assert.Throws<ArgumentNullException>(() => ArrayExtension.MergeSort(array));
        }

        [Test]
        public void MergeSort_ArrayLengthIsZero_ThrowArgumentException()
        {
            int[] array = new int[] { };

            Assert.Throws<ArgumentException>(() => ArrayExtension.MergeSort(array));
            Assert.Throws<ArgumentException>(() => ArrayExtension.MergeSort(array, 0, array.Length - 1));
        }

        [Test]
        public void MergeSort_InsexIsLessThanLowerBoundOfArrayOrLengthIsLessThanZero_ThrowArgumentOutOfRangeException()
        {
            Random random = new Random();
            int[] array = new int[BigArraySize];

            Assert.Throws<ArgumentOutOfRangeException>(() => ArrayExtension.MergeSort(array, -4, 50));
            Assert.Throws<ArgumentOutOfRangeException>(() => ArrayExtension.MergeSort(array, 20, -6));
            Assert.Throws<ArgumentOutOfRangeException>(() => ArrayExtension.MergeSort(array, BigArraySize, 10));
            Assert.Throws<ArgumentOutOfRangeException>(() => ArrayExtension.MergeSort(array, 10, BigArraySize));
        }
        #endregion
    }
}
