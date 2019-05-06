using System.Globalization;
using NUnit.Framework;

namespace NET1.S._2019.Tsyvis._04.Tests
{
    [TestFixture]
    public class BinaryRepresentationFormatProviderTests
    {
        [TestCase(
            -255.255,
            ExpectedResult = "-255,255 = 1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(
            255.255,
            ExpectedResult = "255,255 = 0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(
            4294967295.0,
            ExpectedResult = "4294967295 = 0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(-0.0, ExpectedResult = "0 = 1000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(0.0, ExpectedResult = "0 = 0000000000000000000000000000000000000000000000000000000000000000")]
        public string TransformToBinaryDoubleNumber(double number) => number.ToString("DB", new BinaryRepresentationFormatProvider());
        //string.Format(new BinaryRepresentationFormatProvider(new CultureInfo("ru")), "{0} = {0:DB}", number);

        [TestCase(5, ExpectedResult = "5 = 5")]
        public string TransformToBinaryIntegerNumber(int number) =>
            string.Format(new BinaryRepresentationFormatProvider(new CultureInfo("ru")), "{0} = {0:DB}", number);

    }
}
