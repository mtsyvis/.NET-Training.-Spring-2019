using System;
using System.Linq.Expressions;
using NET1.S._2019.Tsyvis._23.Matrices;

namespace NET1.S._2019.Tsyvis._23.Visitors
{
    /// <summary>
    /// Provide addition different matrix.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MatrixAdditionVisitor<T>
        where T : struct
    {
        /// <summary>
        /// Dynamics the visit.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="anotherMatrix">Another matrix.</param>
        /// <returns>Added matrix</returns>
        public Matrix<T> DynamicVisit(Matrix<T> matrix, Matrix<T> anotherMatrix)
        {
            return Visit((dynamic)matrix, (dynamic)anotherMatrix);
        }

        private Matrix<T> Visit(SquareMatrix<T> squareMatrix, Matrix<T> anotherMatrix)
        {
            return new SquareMatrix<T>(AdditionMatrix(squareMatrix, anotherMatrix));
        }

        private Matrix<T> Visit(Matrix<T> matrix, SquareMatrix<T> squareMatrix) => Visit(squareMatrix, matrix);

        private Matrix<T> Visit(DiagonalMatrix<T> diagonalMatrix, DiagonalMatrix<T> diagonalAnotherMatrix)
        {
            return new DiagonalMatrix<T>(AdditionMatrix(diagonalMatrix, diagonalAnotherMatrix));
        }

        private Matrix<T> Visit(SymmetricMatrix<T> symmetricMatrix, SymmetricMatrix<T> symmetricAnotherMatrix)
        {
            return new DiagonalMatrix<T>(AdditionMatrix(symmetricMatrix, symmetricAnotherMatrix));
        }
        private Matrix<T> Visit(SymmetricMatrix<T> symmetricMatrix, DiagonalMatrix<T> diagonalMatrix)
        {
            return new SquareMatrix<T>(AdditionMatrix(symmetricMatrix, diagonalMatrix));
        }

        private Matrix<T> Visit(DiagonalMatrix<T> diagonalMatrix, SymmetricMatrix<T> symmetricMatrix) =>
            Visit(symmetricMatrix, diagonalMatrix);


        private T[,] AdditionMatrix(Matrix<T> matrix, Matrix<T> anotherMatrix)
        {
            if (matrix.RowCount != anotherMatrix.RowCount || matrix.ColumnCount != anotherMatrix.ColumnCount)
            {
                throw new ArgumentException("It is impossible to fold matrices of different sizes");
            }

            var result = new T[matrix.RowCount, matrix.ColumnCount];
            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    result[i, j] = Add(matrix[i, j], anotherMatrix[i, j]);
                }
            }

            return result;
        }

        private T Add(T lhs, T rhs)
        {
            ParameterExpression paramA = Expression.Parameter(typeof(T), "elem1"),
                                paramB = Expression.Parameter(typeof(T), "elem2");
            BinaryExpression body = Expression.Add(paramA, paramB);

            Func<T, T, T> add = Expression
                .Lambda<Func<T, T, T>>(body, paramA, paramB)
                .Compile();

            return add(lhs, rhs);
        }
    }
}
