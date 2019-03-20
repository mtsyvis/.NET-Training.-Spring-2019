using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
