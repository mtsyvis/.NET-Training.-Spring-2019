using System;
using NUnit.Framework;

namespace NET1.S._2019.Tsyvis._12.Tests
{
    [TestFixture]
    public class PrimeNumberGeneratorTests
    {
        [Test]
        public void GetSequence_From2ToStopNumberTest()
        {
            long stopNumber = 30;
            var expectedSequence = new long[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
            var actualSequence = PrimeNumberGenerator.GetSequence(stopNumber);
            Assert.AreEqual(expectedSequence, actualSequence);
        }
    }
}
