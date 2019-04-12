using NUnit.Framework;
using NET1.S._2019.Tsyvis._07.Filter;
using NET1.S._2019.Tsyvis._07.Sort;
using NET1.S._2019.Tsyvis._07.Transform;
using NET1.S._2019.Tsyvis._07.Sort_jagged_array;
using NET1.S._2019.Tsyvis._07.Transform.TransformRules;

namespace NET1.S._2019.Tsyvis._07.Tests
{
    using System;

    [TestFixture]
    public class ArrayExtensionTests
    {
        #region Filter

        [Test]
        public void Filter_ContainNumberDigitFilterTest()
        {
            var actualArray = new int[] { 7, 1, 2, -375, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            var expectedArray = new int[] { 7, -375, 7, 70, 17 };

            actualArray = actualArray.Filter(new ContainNumberDigitPredicate<int>('7'));

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void Filter_DoubleArrayContainNumberDigitFilterTest()
        {
            var actualArray = new double[] { 7.12, 1, 2, -375.2, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            var expectedArray = new double[] { 7.12, -375.2, 7, 70, 17 };

            actualArray = actualArray.Filter(new ContainNumberDigitPredicate<double>('7'));

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void Filter_EvenNumberFilterTest()
        {
            var actualArray = new int[] { 2, -10, 13, 55, -33, 22 };
            var expectedArray = new int[] { 2, -10, 22 };

            actualArray = actualArray.Filter(new EvenNumberPredicate());

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void Filter_PolindromeNumberFilterTest()
        {
            var actualArray = new int[] { 2, 313, 34, 31013, 55, 1234, 3443};
            var expectedArray = new int[] { 2, 313, 31013, 55, 3443 };

            actualArray = actualArray.Filter(new PalindromeNumberPredicate<int>());

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        #endregion

        #region Transform double

        [Test]
        public void Transform_ByBinaryRepresentationRuleTest()
        {
            var actualArray = new double[] { -255.255, -0.0, double.MinValue };
            var expectedArray = new string[]
                                    {
                                        "1100000001101111111010000010100011110101110000101000111101011100",
                                        "1000000000000000000000000000000000000000000000000000000000000000",
                                        "1111111111101111111111111111111111111111111111111111111111111111"
                                    };

            Assert.AreEqual(expectedArray, actualArray.Transform(new TransformDoubleToBinaryRepresentationRule()));
        }

        [Test]
        public void Transform_ByWordRouleWithEnglishDictionaryTest()
        {
            var actualArray = new double[] { -23.809, 0.295, 15.17 };
            var expectedArray = new string[]
                                    {
                                        "minus two three point eight zero nine", "zero point two nine five",
                                        "one five point one seven"
                                    };
            var rule = new TransformDoubleToWordRule<double>(new EnglishDictionaryCreator());

            Assert.AreEqual(expectedArray,actualArray.Transform(rule));
        }

        [Test]
        public void Transform_ByWordRouleWithRussianDictionaryTest()
        {
            var actualArray = new double[] { -23.809, 0.295};
            var expectedArray = new string[] { "минус два три точка восемь ноль девять", "ноль точка два девять пять" };

            var rule = new TransformDoubleToWordRule<double>(new RussianDictionaryCreator());

            Assert.AreEqual(expectedArray, actualArray.Transform(rule));
        }

        #endregion

        #region Sort string array

        [Test]
        public void Sort_LengthDescendingComparerTest()
        {
            var actualArray = new string[] { "aaa", "bbbbb", "cccc", "32", "1" };
            var expectedArray = new string[] { "bbbbb", "cccc", "aaa", "32", "1" };

            Assert.AreEqual(expectedArray, actualArray.Sort(new LengthDescendingComparer()));
        }

        [Test]
            public void Sort_LengthAscendingComparerTest()
        {
            var actualArray = new string[] { "aaa", "bbbbb", "cccc", "32", "1" };
            var expectedArray = new string[] { "1", "32", "aaa", "cccc", "bbbbb" };

            Assert.AreEqual(expectedArray, actualArray.Sort(new LengthAscendingComparer()));
        }

        [Test]
        public void Sort_NumberOfEntriesAscendingComparerTest()
        {
            var actualArray = new string[] { "aba", "bbbbb", "bbcc", "32", "1bbb" };
            var expectedArray = new string[] { "32", "aba", "bbcc", "1bbb", "bbbbb" };

            Assert.AreEqual(expectedArray, actualArray.Sort(new NumberOfEntriesAscendingComparer('b')));
        }

        [Test]
        public void Sort_NumberOfEntriesDescendingComparerTest()
        {
            var actualArray = new string[] { "aba", "bbbbb", "bbcc", "32", "1bbb" };
            var expectedArray = new string[] { "bbbbb", "1bbb", "bbcc", "aba", "32" };

            Assert.AreEqual(expectedArray, actualArray.Sort(new NumberOfEntriesDescendingComparer('b')));
        }

        #endregion

        #region Sort jagged array

        [Test]
        public void SortJaggedArray_JaggedArrayMaxValueDescendingComparerTest()
        {
            int[][] actualMatrix = new int[4][];
            actualMatrix[0] = new int[] { 10, 9, 109, 20 };
            actualMatrix[1] = new int[] { 1000 };
            actualMatrix[2] = new int[] { 120, 80, 700 };
            actualMatrix[3] = new int[] { 4, 2 };

            int[][] expectedMatrix = new int[4][];
            expectedMatrix[0] = new int[] { 1000 };
            expectedMatrix[1] = new int[] { 120, 80, 700 };
            expectedMatrix[2] = new int[] { 10, 9, 109, 20 };
            expectedMatrix[3] = new int[] { 4, 2 };

            CollectionAssert.AreEqual(expectedMatrix, actualMatrix.SortJaggedArray(new JaggedArrayMaxValueDescendingComparer()));
        }

        [Test]
        public void SortJaggedArray_JaggedArrayMaxValueAscendingComparerTest()
        {
            int[][] actualMatrix = new int[4][];
            actualMatrix[0] = new int[] { 10, 9, 109, 20 };
            actualMatrix[1] = new int[] { 1000 };
            actualMatrix[2] = new int[] { 120, 80, 700 };
            actualMatrix[3] = new int[] { 4, 2 };

            int[][] expectedMatrix = new int[4][];
            expectedMatrix[0] = new int[] { 4, 2 };
            expectedMatrix[1] = new int[] { 10, 9, 109, 20 };
            expectedMatrix[2] = new int[] { 120, 80, 700 };
            expectedMatrix[3] = new int[] { 1000 };

            CollectionAssert.AreEqual(expectedMatrix, actualMatrix.SortJaggedArray(new JaggedArrayMaxValueAscendingComparer()));
        }

        [Test]
        public void SortJaggedArray_JaggedArrayMinValueAscendingComparerTest()
        {
            int[][] actualMatrix = new int[4][];
            actualMatrix[0] = new int[] { 10, 9, 109, 20 };
            actualMatrix[1] = new int[] { 1000, 600, -100 };
            actualMatrix[2] = new int[] { 120, 80, 700 };
            actualMatrix[3] = new int[] { 4, 2 };

            int[][] expectedMatrix = new int[4][];
            expectedMatrix[0] = new int[] { 1000, 600, -100 };
            expectedMatrix[1] = new int[] { 4, 2 };
            expectedMatrix[2] = new int[] { 10, 9, 109, 20 };
            expectedMatrix[3] = new int[] { 120, 80, 700 };

            CollectionAssert.AreEqual(expectedMatrix, actualMatrix.SortJaggedArray(new JaggedArrayMinValueAscendingComparer()));
        }

        [Test]
        public void SortJaggedArray_JaggedArrayMinValueDescendingComparerTest()
        {
            int[][] actualMatrix = new int[4][];
            actualMatrix[0] = new int[] { 10, 9, 109, 20 };
            actualMatrix[1] = new int[] { 1000, 600, -100 };
            actualMatrix[2] = new int[] { 120, 80, 700 };
            actualMatrix[3] = new int[] { 4, 2 };

            int[][] expectedMatrix = new int[4][];
            expectedMatrix[0] = new int[] { 120, 80, 700 };
            expectedMatrix[1] = new int[] { 10, 9, 109, 20 };
            expectedMatrix[2] = new int[] { 4, 2 };
            expectedMatrix[3] = new int[] { 1000, 600, -100 };

            CollectionAssert.AreEqual(expectedMatrix, actualMatrix.SortJaggedArray(new JaggedArrayMinValueDescendingComparer()));
        }

        [Test]
        public void SortJaggedArray_JaggedArraySumValuesDescendingComparerTest()
        {
            int[][] actualMatrix = new int[4][];
            actualMatrix[0] = new int[] { 10, 9, 109, 20 };
            actualMatrix[1] = new int[] { 1000, 600, -100 };
            actualMatrix[2] = new int[] { 120, 80, 700 };
            actualMatrix[3] = new int[] { 4, 2 };

            int[][] expectedMatrix = new int[4][];
            expectedMatrix[0] = new int[] { 1000, 600, -100 };
            expectedMatrix[1] = new int[] { 120, 80, 700 };
            expectedMatrix[2] = new int[] { 10, 9, 109, 20 };
            expectedMatrix[3] = new int[] { 4, 2 };

            CollectionAssert.AreEqual(expectedMatrix, actualMatrix.SortJaggedArray(new JaggedArraySumValuesDescendingComparer()));
        }

        [Test]
        public void SortJaggedArray_JaggedArraySumValuesAscendingComparerTest()
        {
            int[][] actualMatrix = new int[4][];
            actualMatrix[0] = new int[] { 10, 9, 109, 20 };
            actualMatrix[1] = new int[] { 1000, 600, -100 };
            actualMatrix[2] = new int[] { 120, 80, 700 };
            actualMatrix[3] = new int[] { 4, 2 };

            int[][] expectedMatrix = new int[4][];
            expectedMatrix[0] = new int[] { 4, 2 };
            expectedMatrix[1] = new int[] { 10, 9, 109, 20 };
            expectedMatrix[2] = new int[] { 120, 80, 700 };
            expectedMatrix[3] = new int[] { 1000, 600, -100 };

            CollectionAssert.AreEqual(expectedMatrix, actualMatrix.SortJaggedArray(new JaggedArraySumValuesAscendingComparer()));
        }

        #endregion

        #region Transform string to number in the desired number system

        [Test]
        public void Transform_ByTransformStringToNumberRule2NumberSystem_WellTransformed()
        {
            var actualArray = new string[] { "101", "10" };
            var expectedArray = new int[] { 5, 2 };

            var rule = new TransformStringToNumberRule(2);

            Assert.AreEqual(expectedArray, actualArray.Transform(rule));
        }

        [Test]
        public void Transform_ByTransformStringToNumberRule16NumberSystem_WellTransformed()
        {
            var actualArray = new string[] { "FFA2", "A" };
            var expectedArray = new int[] { 65442, 10 };

            var rule = new TransformStringToNumberRule(16);

            Assert.AreEqual(expectedArray, actualArray.Transform(rule));
        }

        [Test]
        public void Transform_ByTransformStringToNumberRuleStringHaveWrongSymbols_ThrowArgumentException()
        {
            var actualArray = new string[] { "FF!143#A2", "A" };

            Assert.Throws<ArgumentException>(() => actualArray.Transform(new TransformStringToNumberRule(3)));
        }

        [Test]
        public void Transform_ByTransformStringToNumberRuleStringIsNotStringSuitableForNumberSystem_ThrowArgumentException()
        {
            var actualArray = new string[] { "514",};
            var numberSystemBase = 3;

            Assert.Throws<ArgumentException>(() => actualArray.Transform(new TransformStringToNumberRule(numberSystemBase)));
        }

        #endregion
    }
}
