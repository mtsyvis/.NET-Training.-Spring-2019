using NUnit.Framework;

namespace NET1.S._2019.Tsyvis._11.Tests
{
    [TestFixture]
    public class ArrayExtensionsTests
    {
        [TestCase(new int[] { -6, 0, 2, 10, 22, 100 }, -6, ExpectedResult = 0)]
        [TestCase(new int[] { -6, 0, 2, 10, 22, 100 }, 100, ExpectedResult = 5)]
        [TestCase(new int[] { 2, 6, 10, 12, 30 }, 10, ExpectedResult = 2)]
        [TestCase(new int[] { 2, 6, 10, 12, 30 }, -999923, ExpectedResult = -1)]
        [TestCase(new int[] { 100, 50, 25, 15, 10, -999 }, 10, ExpectedResult = 4)]
        [TestCase(new int[] { }, 7, ExpectedResult = -1)]
        [TestCase(new int[] { 1 }, 1, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 2 }, 2, ExpectedResult = 1)]
        public int BinarySearch_IntArray(int[] array, int value) => array.BinarySearch(value);

        [TestCase(new string[] { "AAA", "aaa", "bbb", "fff" }, "bbb", ExpectedResult = 2)]
        [TestCase(new string[] { "yyy", "fff", "aaa", "YYY" }, "YYY", ExpectedResult = 3)]
        [TestCase(new string[] { "ASD", "sdfsdf", "AASD" }, "bbb", ExpectedResult = -1)]
        public int BinarySearch_StringArray(string[] array, string value) => array.BinarySearch(value);
    }
}
