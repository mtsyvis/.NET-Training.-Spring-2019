using System;
using NUnit.Framework;

namespace NET1.S._2019.Tsyvis._07.Tests
{
    [TestFixture]
    public class ArrayExtensionTests
    {
        [Test]
        public void ArrayExtension_ContainNumberDigitFilterTest()
        {
            var actualArray = new int[] { 7, 1, 2, -375, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            var expectedArray = new int[] { 7, -375, 7, 70, 17 };

            actualArray = actualArray.Filter(new ContainNumberDigitPredicate(7));

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void ArrayExtension_EvenNumberFilterTest()
        {
            var actualArray = new int[] { 2, -10, 13, 55, -33, 22 };
            var expectedArray = new int[] { 2, -10, 22 };

            actualArray = actualArray.Filter(new EvenNumberPredicate());

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void ArrayExtension_PolindromeNumberFilterTest()
        {
            var actualArray = new int[] { 2, 313, 34, 31013, 55, 1234, 3443};
            var expectedArray = new int[] { 2, 313, 31013, 55, 3443 };

            actualArray = actualArray.Filter(new PalindromeNumberPredicate());

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }
    }
}
