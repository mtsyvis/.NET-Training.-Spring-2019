using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NET1.S._2019.Tsyvis._12.Tests
{
    [TestFixture]
    public class StrikingOutInCircleProcessTests
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, ExpectedResult = 8)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, ExpectedResult = 6)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, ExpectedResult = 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, ExpectedResult = 2)]
        [TestCase(new int[] { 1, 2, 3, 4 }, ExpectedResult = 4)]
        [TestCase(new int[] { 1, 2, 3 }, ExpectedResult = 2)]
        [TestCase(new int[] { 1, 2 }, ExpectedResult = 2)]
        [TestCase(new int[] { 1 }, ExpectedResult = 1)]
        public int StartStrikingOut_StartFromFirst_IntArray(IEnumerable<int> array)
        {
            StrikingOutInCircleProcess<int> action = new StrikingOutInCircleProcess<int>(array);

            return action.StartStrikingOut();
        }

        [Test]
        public void StartStrikingOut_StartFromFirst_StringArray()
        {
            var array = new string[] { "vasya", "oleg", "valik", "lena", "misha" };

            var action = new StrikingOutInCircleProcess<string>(array);

            Assert.AreEqual("oleg", action.StartStrikingOut());
        }

        [Test]
        public void StartStrikingOut_ArrayIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new StrikingOutInCircleProcess<string>(null));
        }
    }
}
