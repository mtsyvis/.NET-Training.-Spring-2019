using System;
using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._23.Matrices
{
    /// <summary>
    /// Provide manipulation with diagonal matrix.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="NET1.S._2019.Tsyvis._23.Matrices.Matrix{T}" />
    public class DiagonalMatrix<T> : Matrix<T>
        where T : struct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="diagonal">The diagonal.</param>
        public DiagonalMatrix(T[] diagonal) : base(ConvertToDoubleDimensionalArray(diagonal))
        {
        }

        /// <summary>
        /// Sets the <see cref="T"/> with the specified i.
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">It is possible to set the values only on the diagonal</exception>
        public override T this[int i, int j]
        {
            set
            {
                if (i != j)
                {
                    throw new ArgumentException("It is possible to set the values only on the diagonal");
                }

                base[i, j] = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <exception cref="ArgumentException">
        /// Array is not a square matrix
        /// or
        /// Array is not a diagonal matrix
        /// </exception>
        public DiagonalMatrix(T[,] array)
            : base(array)
        {
            if (array.GetLength(0) != array.GetLength(1))
            {
                throw new ArgumentException("Array is not a square matrix");
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (Comparer<T>.Default.Compare(array[i, j], default(T)) != 0)
                    {
                        throw new ArgumentException("Array is not a diagonal matrix");
                    }
                }
            }
        }

        private static T[,] ConvertToDoubleDimensionalArray(T[] array)
        {
            var matrix = new T[array.Length, array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                matrix[i, i] = array[i];
            }

            return matrix;
        }
    }
}
