using NUnit.Framework;
using GcdCalculationDecorator;

namespace NET1.S._2019.Tsyvis._08.Tests
{
    [TestFixture]
    public class GCDCalculatorTests
    {
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(2, 4, ExpectedResult = 2)]
        [TestCase(10927782, -6902514, ExpectedResult = 846)]
        public int CalculateGcd_BinaryGcdAlgorithmTest(int a, int b)
            => GCDCalculator.Calculate(new ExecutionTimeCountDecorator(new BinaryGcdAlgorithm(), new StopwatchAdapter()), a, b);

        [TestCase(1, 3, ExpectedResult = 1)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(10927782, -6902514, ExpectedResult = 846)]
        public int CalculateGcd_EuclideanGcdAlgorithmTest(int a, int b)
            => GCDCalculator.Calculate(new ExecutionTimeCountDecorator(new EuclideanGcdAlgorithm(), new StopwatchAdapter()), a, b);
    }
}
