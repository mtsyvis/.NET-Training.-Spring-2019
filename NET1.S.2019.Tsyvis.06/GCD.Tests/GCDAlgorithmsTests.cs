using System;
using NUnit.Framework;
using NET1.S._2019.Tsyvis._06;

namespace GCD.Tests
{
    [TestFixture]
    public class GCDAlgorithmsTests
    {
        #region GCD by Euclidean calculation tests

        [TestCase(12, 6, 3, ExpectedResult = 3)]
        [TestCase(0, 0, 0, 4, ExpectedResult = 4)]
        [TestCase(1, 3, ExpectedResult = 1)]
        [TestCase(30, 12, ExpectedResult = 6)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(8, 9, ExpectedResult = 1)]
        [TestCase(50, 250, ExpectedResult = 50)]
        [TestCase(10927782, -6902514, ExpectedResult = 846)]
        public int CalculateGcdByEuclideanAndTime_ManyParams(params int[] array)
            => GCDAlgorithms.CalculateGcdByEuclideanAndTime(out _, array);

        [TestCase(1, 3, ExpectedResult = 1)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(10927782, -6902514, ExpectedResult = 846)]
        public int CalculateGcdByEuclideanAndTime_For2Params(int a, int b)
            => GCDAlgorithms.CalculateGcdByEuclideanAndTime(a, b, out _);

        [TestCase(12, 6, 3, ExpectedResult = 3)]
        public int CalculateGcdByEuclideanAndTime_For3Params(int a, int b, int c)
            => GCDAlgorithms.CalculateGcdByEuclideanAndTime(a, b, c, out _);

        #endregion

        #region GCD by Stein calculation tests

        [TestCase(12, 6, 3, ExpectedResult = 3)]
        [TestCase(0, 0, 0, 4, ExpectedResult = 4)]
        [TestCase(1, 3, ExpectedResult = 1)]
        [TestCase(30, 12, ExpectedResult = 6)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(8, 9, ExpectedResult = 1)]
        [TestCase(50, 250, ExpectedResult = 50)]
        [TestCase(10927782, -6902514, ExpectedResult = 846)]
        public int CalculateGcdBySteinAndTime_ManyParams(params int[] array)
            => GCDAlgorithms.CalculateGcdBySteinAndTime(out _, array);

        [TestCase(1, 3, ExpectedResult = 1)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(10927782, -6902514, ExpectedResult = 846)]
        public int CalculateGcdBySteinAndTime_For2Params(int a, int b)
            => GCDAlgorithms.CalculateGcdBySteinAndTime(a, b, out _);

        [TestCase(12, 6, 3, ExpectedResult = 3)]
        public int CalculateGcdBySteinAndTime_For3Params(int a, int b, int c)
            => GCDAlgorithms.CalculateGcdBySteinAndTime(a, b, c, out _);

        #endregion
    }
}
