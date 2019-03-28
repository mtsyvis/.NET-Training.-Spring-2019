using System;
using NUnit.Framework;

namespace NET1.S._2019.Tsyvis._03.Tests
{
    [TestFixture]
    public class MathExtensionsTests
    {
        #region Find Nth root
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void FindNthRootTest_NumberAndDegreeOfRoot(double a, int n, double accuracy, double expectedResult)
            => Assert.AreEqual(expectedResult, MathExtensions.FindNthRoot(a, n, accuracy), accuracy);

        [Test]
        public void FindNthRoot_PowerIsLessThen0_ThrowArgumentException()
        {
            double a = 0.001, accurancy = 0.0001;
            int n = -2;
            Assert.Throws<ArgumentException>(() => MathExtensions.FindNthRoot(a, n, accurancy));
        }

        [Test]
        public void FindNthRoot_AccuracyIsLessThen0_ThrowArgumentException()
        {
            double a = 0.001, accurancy = -1;
            int n = 2;
            Assert.Throws<ArgumentException>(() => MathExtensions.FindNthRoot(a, n, accurancy));
        }

        [Test]
        public void FindNthRoot_NumberIsLessThen0AndPowerIsEven_ThrowArgumentException()
        {
            double a = -0.001, accurancy = 1;
            int n = 2;
            Assert.Throws<ArgumentException>(() => MathExtensions.FindNthRoot(a, n, accurancy));
        }
        #endregion

        #region Next bigger than
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(124121133, ExpectedResult = 124121313)]
        [TestCase(int.MaxValue, ExpectedResult = null)]
        [TestCase(2000, ExpectedResult = null)]
        [TestCase(111111111, ExpectedResult = null)]
        public int? NextBiggerThanTest(int number)
            => MathExtensions.NextBiggerThan(number);

        public void NextBiggerThan_NegativeNumber_ThrowArgumentException()
        {
            int nummer = -10;

            Assert.Throws<ArgumentException>(() => MathExtensions.NextBiggerThan(nummer));
        }
        #endregion
    }
}
