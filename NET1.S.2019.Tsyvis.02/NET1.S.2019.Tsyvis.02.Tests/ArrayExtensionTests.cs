using System;
using NUnit.Framework;

namespace NET1.S._2019.Tsyvis._02.Tests
{
    [TestFixture]
    class ArrayExtensionTests
    {
        [TestCase(new int[] { 1 }, ExpectedResult = 1)]
        [TestCase(new int[] { 1, -20, 0, 100 }, ExpectedResult = 100)]
        [TestCase(new int[] { int.MaxValue, 45, 100, 241341, int.MinValue }, ExpectedResult = int.MaxValue)]
        public int FindMaxValue_WellValue(int[] array) => ArrayExtension.FindMaxValue(array);

        [Test]
        public void FindMaxValue_ArrayIsNull_ThrowArgumentNullException()
        {
            int[] array = null;

            Assert.Throws<ArgumentNullException>(() => ArrayExtension.FindMaxValue(array));
        }

        [Test]
        public void FindMaxValue_LengthOfArrayIs0_ThrowArgumentException()
        {
            int[] array = new int[] { };

            Assert.Throws<ArgumentException>(() => ArrayExtension.FindMaxValue(array));
        }
    }
}
