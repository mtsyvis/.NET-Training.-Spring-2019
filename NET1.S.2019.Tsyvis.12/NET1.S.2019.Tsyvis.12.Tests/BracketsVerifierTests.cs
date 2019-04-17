using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NET1.S._2019.Tsyvis._12.Tests
{
    [TestFixture]
    public class BracketsVerifierTests
    {
        [TestCase("([])", ExpectedResult = true)]
        [TestCase("( ([])   { [{ }] } )", ExpectedResult = true)]
        [TestCase("( [ )", ExpectedResult = false)]
        [TestCase("]]]]]]", ExpectedResult = false)]
        [TestCase("vasya", ExpectedResult = false)]
        [TestCase("}}}}}}(", ExpectedResult = false)]
        public bool AreBracketsCorrectlySpacedTest(string str) => BracketsVerifier.AreBracketsCorrectlySpaced(str);

        [Test]
        public void AreBracketsCorrectlySpaced_StringIsNullThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => BracketsVerifier.AreBracketsCorrectlySpaced(null));
        }
        

    }
}
