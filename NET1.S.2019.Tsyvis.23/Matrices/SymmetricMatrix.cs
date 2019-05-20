using System;
using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._23.Matrices
{
    /// <summary>
    /// Provide manipulation with symmetric matrix.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="NET1.S._2019.Tsyvis._23.Matrices.Matrix{T}" />
    public class SymmetricMatrix<T> : Matrix<T>
        where T : struct
    {
        /// <summary>
        /// Sets the <see cref="T"/> with the specified i.
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns>Matrix item</returns>
        public override T this[int i, int j]
        {
            set
            {
                if (i >= j)
                {
                    base[i, j] = value;
                }
                else
                {
                    base[j, i] = value;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricMatrix{T}"/> class.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <exception cref="ArgumentException">
        /// Array is not a square matrix
        /// or
        /// Array is not a symmetric matrix
        /// </exception>
        public SymmetricMatrix(T[,] array)
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
                    if (Comparer<T>.Default.Compare(array[i, j], array[j, i]) != 0)
                    {
                        throw new ArgumentException("Array is not a symmetric matrix");
                    }
                }
            }
        }
    }
}
