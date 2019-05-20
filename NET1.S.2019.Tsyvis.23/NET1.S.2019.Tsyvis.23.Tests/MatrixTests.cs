using System;
using NUnit.Framework;

namespace NET1.S._2019.Tsyvis._23.Tests
{
    using NET1.S._2019.Tsyvis._23.Matrices;

    [TestFixture]
    public class MatrixTests
    {
        [Test]
        public void AdditionSquareAndDiagonalMatrixTest()
        {
            var squareMatrixArray = new int[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
            var diagonalMatrixArray = new int[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };

            var squareMatrix = new SquareMatrix<int>(squareMatrixArray);
            var diagonalMatrix = new DiagonalMatrix<int>(diagonalMatrixArray);

            var resultArray = new int[,] { { 2, 1, 1 }, { 1, 2, 1 }, { 1, 1, 2 } };

            var actualMatrix = squareMatrix.Addition(diagonalMatrix);
            var expectedMatrix = new SquareMatrix<int>(resultArray);

            Assert.AreEqual(expectedMatrix, actualMatrix);
        }

        [Test]
        public void AdditionDiagonalAndDiagonalMatrixTest()
        {
            var array1 = new int[,] { { 5, 0, 0 }, { 0, 2, 0 }, { 0, 0, 4 } };
            var array2 = new int[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };

            var resultArray = new int[,] { { 6, 0, 0 }, { 0, 3, 0 }, { 0, 0, 5 } };

            var actualMatrix = MatrixExtensions.Addition(new DiagonalMatrix<int>(array2), new DiagonalMatrix<int>(array1));
            var expectedMatrix = new DiagonalMatrix<int>(resultArray);

            Assert.AreEqual(expectedMatrix, actualMatrix);
        }

        [Test]
        public void AdditionSymmetricAndDiagonalMatrixTest()
        {
            var symmetricArray = new int[,] { { 1, 2, 3 }, { 2, 5, 4 }, { 3, 4, 1 } };
            var diagonalArray = new int[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };

            var resultArray = new int[,] { { 2, 2, 3 }, { 2, 6, 4 }, { 3, 4, 2 } };

            var actualMatrix = MatrixExtensions.Addition(new SymmetricMatrix<int>(symmetricArray), new DiagonalMatrix<int>(diagonalArray));
            var expectedMatrix = new SquareMatrix<int>(resultArray);

            Assert.AreEqual(expectedMatrix, actualMatrix);
        }

        [Test]
        public void ChangeItemDiagonalMatrix_ThrowArgumentException()
        {
            var diagonalArray = new int[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };

            var matrix = new DiagonalMatrix<int>(diagonalArray);

            Assert.Throws<ArgumentException>(() => matrix[0, 1] = 4);
        }

        [Test]
        public void ChangeItemDiagonalMatrix_ThrowArgumentOutOfRangeException()
        {
            var array = new int[,] { { 1, 2, 3 }, { 2, 5, 4 }, { 3, 4, 1 } };

            var matrix = new SymmetricMatrix<int>(array);

            Assert.Throws<ArgumentOutOfRangeException>(() => matrix[100, 200] = 4);
        }
    }
}
