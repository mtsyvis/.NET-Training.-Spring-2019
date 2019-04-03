using System;
using NUnit.Framework;

namespace NET1.S._2019.Tsyvis._07.Tests
{
    using NET1.S._2019.Tsyvis._07.Transform;

    [TestFixture]
    public class ArrayExtensionTests
    {
        #region Filter

        [Test]
        public void Filter_ContainNumberDigitFilterTest()
        {
            var actualArray = new int[] { 7, 1, 2, -375, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            var expectedArray = new int[] { 7, -375, 7, 70, 17 };

            actualArray = actualArray.Filter(new ContainNumberDigitPredicate(7));

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void Filter_EvenNumberFilterTest()
        {
            var actualArray = new int[] { 2, -10, 13, 55, -33, 22 };
            var expectedArray = new int[] { 2, -10, 22 };

            actualArray = actualArray.Filter(new EvenNumberPredicate());

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void Filter_PolindromeNumberFilterTest()
        {
            var actualArray = new int[] { 2, 313, 34, 31013, 55, 1234, 3443};
            var expectedArray = new int[] { 2, 313, 31013, 55, 3443 };

            actualArray = actualArray.Filter(new PalindromeNumberPredicate());

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        #endregion

        #region Transform double

        [Test]
        public void Transform_ByBinaryRepresentationRuleTest()
        {
            var actualArray = new double[] { -255.255, -0.0, double.MinValue };
            var expectedArray = new string[]
                                    {
                                        "1100000001101111111010000010100011110101110000101000111101011100",
                                        "1000000000000000000000000000000000000000000000000000000000000000",
                                        "1111111111101111111111111111111111111111111111111111111111111111"
                                    };

            Assert.AreEqual(expectedArray, actualArray.Transform(new TransformDoubleToBinaryRepresentationRule()));
        }

        [Test]
        public void Transform_ByWordRouleWithEnglishDictionaryTest()
        {
            var actualArray = new double[] { -23.809, 0.295, 15.17 };
            var expectedArray = new string[]
                                    {
                                        "minus two three point eight zero nine", "zero point two nine five",
                                        "one five point one seven"
                                    };
            var rule = new TransformDoubleToWordRule(new EnglishDictionaryCreator());

            Assert.AreEqual(expectedArray,actualArray.Transform(rule));
        }

        [Test]
        public void Transform_ByWordRouleWithRussianDictionaryTest()
        {
            var actualArray = new double[] { -23.809, 0.295};
            var expectedArray = new string[] { "минус два три точка восемь ноль девять", "ноль точка два девять пять" };

            var rule = new TransformDoubleToWordRule(new RussianDictionaryCreator());

            Assert.AreEqual(expectedArray, actualArray.Transform(rule));
        }

        #endregion
    }
}
