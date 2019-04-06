using System;
using NUnit.Framework;

namespace NET1.S._2019.Tsyvis._08.Tests
{
    using GcdCalculationDecorator;

    [TestFixture]
    public class GCDCalculationTests
    {
        [TestCase(1, 3, ExpectedResult = 1)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(10927782, -6902514, ExpectedResult = 846)]
        public int CalculateGcdByEuclideanAndTime_For2Params(int a, int b)
            => GCDCalculation.CalculateGcdByEuclideanAndTime(a, b, out _);

        [TestCase(1, 3, ExpectedResult = 1)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(10927782, -6902514, ExpectedResult = 846)]
        public int CalculateGcdBySteinAndTime_For2Params(int a, int b)
            => GCDCalculation.CalculateGcdByStainAndTime(a, b, out _);
    }
}
