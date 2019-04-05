using System;
using NUnit.Framework;

namespace NET1.S._2019.Tsyvis._04.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        [Test]
        public void PolynomialOperatorAdditionTest1()
        {
            var a = new Polynomial(1, 3, 4, -10);
            var b = new Polynomial(-1, 2, 0);
            var expected = new Polynomial(1, 2, 6, -10);

            Polynomial actual = a + b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PolynomialOperatorAdditionTest2()
        {
            var b = new Polynomial(-1, 2, 0);
            var a = new Polynomial(1, 3, 4, -10);
            var expected = new Polynomial(1, 2, 6, -10);

            Polynomial actual = a + b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PolynomialOperatorAdditionTest3()
        {
            var b = new Polynomial(-1, 2, 5);
            var a = new Polynomial(1, 4, 20);
            var expected = new Polynomial(0, 6, 25);

            Polynomial actual = a + b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PolynomialOperatorSubtractionTest1()
        {
            var a = new Polynomial(1, 3, 4, -10);
            var b = new Polynomial(1, 2, 0);
            var expected = new Polynomial(1, 2, 2, -10);

            Polynomial actual = a - b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PolynomialOperatorSubtractionTest2()
        {
            var a = new Polynomial(0, 0, 0);
            var b = new Polynomial(-2, -3, 4, -1);
            var expected = new Polynomial(2, 3, -4, 1);

            Polynomial actual = a - b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PolynomialOperatorSubtractionTest3()
        {
            var a = new Polynomial(3, 4, 1);
            var b = new Polynomial(2, 6, 0);
            var expected = new Polynomial(1, -2, 1);

            Polynomial actual = a - b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PolynomialMultiplicationByNumberTest1()
        {
            var a = new Polynomial(1, -2, 3);
            var expected = new Polynomial(2, -4, 6);

            Polynomial actual = a * 2;

            Assert.AreEqual(actual,expected);
        }

        [Test]
        public void PolynomialMultiplicationByNumberTest2()
        {
            var a = new Polynomial(1, -2, 3);
            var expected = new Polynomial(0, 0, 0);

            Polynomial actual = 0 * a;

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void MultiplicationPolynomialByPolynomialTest1()
        {
            var a = new Polynomial(1, 0, -1);
            var b = new Polynomial(1, 1);
            var expected = new Polynomial(1,1,-1,-1);

            Polynomial actual = a * b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MultiplicationPolynomialByPolynomialTest2()
        {
            var a = new Polynomial(3, 2, -4);
            var b = new Polynomial(2, 0, 1);
            var expected = new Polynomial(6, 4, -5, 2, -4);

            Polynomial actual = a * b;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ClonePolynomialTest()
        {
            var a = new Polynomial(3, 2, -4);
            Polynomial b = null;

            Assert.IsTrue(b == null);
            Assert.IsTrue(a.Equals(a.Clone()));
            Assert.AreEqual(a, a.Clone());
        }
    }
}
