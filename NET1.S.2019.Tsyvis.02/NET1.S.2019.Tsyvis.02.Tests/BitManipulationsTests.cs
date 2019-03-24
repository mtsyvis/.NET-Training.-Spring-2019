using System;
using NUnit.Framework;

namespace NET1.S._2019.Tsyvis._02.Tests
{
    [TestFixture]
    class BitManipulationsTests
    {
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 1, 2, ExpectedResult = 14)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        public int InsertNumberTest(int numberSource, int numberIn, int startBit, int lastBit)
            => BitManipulations.InsertNumber(numberSource, numberIn, startBit, lastBit);

        [Test]
        public void InsertNumber_WrongIndexes_ThrowArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => BitManipulations.InsertNumber(10, 10, 33, 120));
            Assert.Throws<ArgumentOutOfRangeException>(() => BitManipulations.InsertNumber(10, 10, 10, 3));
            Assert.Throws<ArgumentOutOfRangeException>(() => BitManipulations.InsertNumber(10, 10, 0, -6));
            Assert.Throws<ArgumentOutOfRangeException>(() => BitManipulations.InsertNumber(10, 10, -6, 0));
        }
    }
}
