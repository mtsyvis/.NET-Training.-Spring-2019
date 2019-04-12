using System;
using NUnit.Framework;

namespace NET1.S._2019.Tsyvis._11.Tests
{
    [TestFixture]
    public class FibonacciNumberGeneratorTests
    {
        [Test]
        public void GenerateNumberSequences_WellGenerated()
        {
            var expectedSequences = new int[] { 0, 1, 1, 2, 3, 5, 8 };

            var actualSequences = FibonacciNumberGenerator.GenerateNumberSequences(7);

            CollectionAssert.AreEqual(expectedSequences, actualSequences);
        }

        [Test]
        public void GenerateNumberSequences_WronSequencesSize_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => FibonacciNumberGenerator.GenerateNumberSequences(0));
        }
    }
}
