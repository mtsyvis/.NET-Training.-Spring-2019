using NUnit.Framework;
using System;

namespace NET1.S._2019.Tsyvis._04.Tests
{
    [TestFixture]
    public class DoubleExtensionTests
    {
        [TestCase(new double[] { -23.809, 0.295, 15.17 }, ExpectedResult = new string[] {
            "minus two three point eight zero nine", "zero point two nine five", "one five point one seven" })]
        public string[] DoubleExtensionTest(double[] numbers)
            => numbers.Transform();

        [Test]
        public void DoubleExtension_ArrayIsNull_ThrowArgumentNullException()
        {
            double[] array = null;
            Assert.Throws<ArgumentNullException>(() => array.Transform());
        }

        [Test]
        public void DoubleExtension_ArrayLengthIs0_ThrowArgumentException()
        {
            double[] array = new double[] { };
            Assert.Throws<ArgumentException>(() => array.Transform());
        }

        #region Transform to binary format tests
        [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(double.MinValue, ExpectedResult = "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, ExpectedResult = "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.Epsilon, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.NaN, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(-0.0, ExpectedResult = "1000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(0.0, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000000")]
        public string TransformToBinaryTests(double number) => number.TransformToBinary();
        #endregion
    }
}
