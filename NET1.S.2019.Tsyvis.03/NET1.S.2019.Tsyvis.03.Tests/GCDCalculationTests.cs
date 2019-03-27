using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NET1.S._2019.Tsyvis._03.Tests
{
    [TestFixture]
    class GCDCalculationTests
    {
        #region GCD Euclidean calculation tests
        [TestCase(12,6,3, ExpectedResult = 3)]
        [TestCase(0, 0, 0, 4, ExpectedResult = 4)]
        [TestCase(1, 3, ExpectedResult = 1)]
        [TestCase(30, 12, ExpectedResult = 6)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(8, 9, ExpectedResult = 1)]
        [TestCase(50, 250, ExpectedResult = 50)]
        [TestCase(10927782, -6902514, ExpectedResult = 846)]
        public int GCDEuclideanCalculationTest(params int[] array)
            =>GCDCalculation.GCDEuclideanCalculation(out _, array);

        [Test]
        public void GCDEuclideanCalculation_NotArgument_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentException>(() => GCDCalculation.GCDEuclideanCalculation(out _));
        }

        [Test]
        public void GCDEuclideanCalculation_LengthOfArrayIs1_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentException>(() => GCDCalculation.GCDEuclideanCalculation(out _));
        }
        #endregion

        #region GCD Euclidean calculation tests
        [TestCase(12, 6, 3, ExpectedResult = 3)]
        [TestCase(0, 0, 0, 4, ExpectedResult = 4)]
        [TestCase(1, 3, ExpectedResult = 1)]
        [TestCase(30, 12, ExpectedResult = 6)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(8, 9, ExpectedResult = 1)]
        [TestCase(50, 250, ExpectedResult = 50)]
        [TestCase(10927782, -6902514, ExpectedResult = 846)]
        public int GCDBinaryEuclideanCalculationTest(params int[] array)
        {
            var tuple = GCDCalculation.GCDBinaryEuclideanCalculation(array);
            return tuple.gcd;
        }

        [Test]
        public void GCDBinaryEuclideanCalculation_NotArgument_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentException>(() => GCDCalculation.GCDBinaryEuclideanCalculation());
        }

        [Test]
        public void GCDBinaryEuclideanCalculation_LengthOfArrayIs1_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentException>(() => GCDCalculation.GCDBinaryEuclideanCalculation());
        }
        #endregion
    }
}
