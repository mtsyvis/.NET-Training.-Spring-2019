using NUnit.Framework;
using System;

namespace NET1.S._2019.Tsyvis._11.Tests
{
    [TestFixture]
    public class ArrayExtensionsTests
    {
        [TestCase(new int[] { -6, 0, 2, 10, 22, 100 }, 22, ExpectedResult = 4)]
        [TestCase(new int[] { -6, 0, 2, 10, 22, 100 }, 100, ExpectedResult = 5)]
        [TestCase(new int[] { 2, 6, 10, 12, 30 }, 2, ExpectedResult = 0)]
        [TestCase(new int[] { 2, 6, 10, 12, 30 }, -999923, ExpectedResult = -1)]
        [TestCase(new int[] { }, 7, ExpectedResult = -1)]
        [TestCase(new int[] { 1 }, 1, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 2 }, 2, ExpectedResult = 1)]
        public int BinarySearch_IntArray(int[] array, int value) => ArrayExtensions.BinarySearch(array, value, null);

        [TestCase(new string[] { "AAA", "aaa", "bbb", "fff" }, "bbb", ExpectedResult = 2)]
        [TestCase(new string[] { "yyy", "fff", "aaa", "YYY" }, "YYY", ExpectedResult = 3)]
        [TestCase(new string[] { "ASD", "sdfsdf", "AASD" }, "bbb", ExpectedResult = -1)]
        public int BinarySearch_StringArray(string[] array, string value) => array.BinarySearch(value);

        [TestCase(new int[] { -6, 22, 0, 2, 10, 22, 100 }, 2, 3, 22, ExpectedResult = 5)]
        [TestCase(new int[] { 2, 6, 10, 12, 30, 2 }, 0, 3, 2, ExpectedResult = 0)]
        [TestCase(new int[] { 2, 6, 10, 12, 30, 30 }, 2, 3, 30, ExpectedResult = 4)]
        public int BinarySearch_IntArrayWithSetIndexAndLength(int[] array, int index, int length, int value) => array.BinarySearch(index, length, value);

        [Test]
        public void BinarySearch_InvalidIndexOrLength_ThrowArgumentException()
        {
            var array = new int[] { 1, 4 };
            try
            {
                array.BinarySearch<int>(0, 10, 1);
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.IsNotNull(e);
            }
        }

        [Test]
        public void BinarySearch_IndexOrLengthLessThenZero_ThrowArgumentException()
        {
            var array = new int[] { 1, 4 };
            try
            {
                array.BinarySearch<int>(-3, -3, 1, null);
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.IsNotNull(e);
            }
        }
    }
}
