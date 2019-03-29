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
    }
}
