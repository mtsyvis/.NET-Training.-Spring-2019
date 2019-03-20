using NUnit.Framework;
using System;
using NET1.S._2019.Tsyvis._01;

namespace NUnit.Test.Project
{
    [TestFixture]
    public class ArrayExtensionNUnitTests
    {
        private const int BigArraySize = 10000;

        [Test]
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

        [Test]
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
            ArrayExtension.QuickSort(expectedArray, BigArraySize/3, BigArraySize/2);
            Array.Sort(actualArray, BigArraySize / 3, BigArraySize / 2);

            // Assert
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [Test]
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

        [Test]
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

        [Test]
        public void QuickSortAndMergeSort_ArrayIsNull_ThrowArgumentNullException()
        {
            // Arrange
            int[] array = null;

            // Assert
            Assert.That(() => ArrayExtension.MergeSort(array), Throws.TypeOf<ArgumentNullException>());
            Assert.That(() => ArrayExtension.QuickSort(array), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void QuickSortAndMergeSort_ArrayLengthIsZero_ThrowArgumentException()
        {
            // Arrange
            int[] array = new int[] { };

            // Assert
            Assert.That(() => ArrayExtension.MergeSort(array), Throws.TypeOf<ArgumentException>());
            Assert.That(() => ArrayExtension.QuickSort(array), Throws.TypeOf<ArgumentException>());
            Assert.That(() => ArrayExtension.MergeSort(array, 0, array.Length - 1), Throws.TypeOf<ArgumentException>());
            Assert.That(() => ArrayExtension.QuickSort(array, 0, array.Length - 1), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void QuickSortAndMergeSort_InsexIsLessThanLowerBoundOfArrayOrLengthIsLessThanZero_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            Random random = new Random();

            int[] array = new int[BigArraySize];

            // Assert
            Assert.That(() => ArrayExtension.MergeSort(array, -4, 50), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => ArrayExtension.QuickSort(array, -10, 100), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => ArrayExtension.MergeSort(array, 20, -6), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => ArrayExtension.QuickSort(array, 20, -6), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => ArrayExtension.MergeSort(array, BigArraySize, 10), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => ArrayExtension.QuickSort(array, BigArraySize, 20), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => ArrayExtension.MergeSort(array, 10, BigArraySize), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => ArrayExtension.QuickSort(array, 20, BigArraySize), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
        //[Test]
        //public void ArrayElememtIsNull_ThrowArgumentNullException()
        //{
        //    string[] actual = new string[] { "asff", "sdf", null, "adf" };
        //    Assert.Throws<ArgumentNullException>(() => StringExtension.OrderStringsByLength(actual));
        //}
        //index is less than the lower bound of array. -or- length is less than zero.
    }
}
