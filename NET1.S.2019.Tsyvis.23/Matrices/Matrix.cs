using System;
using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._23.Matrices
{
    /// <summary>
    /// Provide manipulation with matrix.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.IEquatable{NET1.S._2019.Tsyvis._23.Matrices.Matrix{T}}" />
    public abstract class Matrix<T> : IEquatable<Matrix<T>> where T : struct
    {
        protected T[,] array;

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix{T}"/> class.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <exception cref="ArgumentNullException">array is null</exception>
        public Matrix(T[,] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException($"array is null");
            }

            this.array = array.Clone() as T[,];
            RowCount = array.GetLength(0);
            ColumnCount = array.GetLength(1);
        }

        /// <summary>
        /// Occurs when matrix elements changed.
        /// </summary>
        public event EventHandler<MatrixChangedEventArgs<T>> MatrixChanged;

        /// <summary>
        /// Gets the row count.
        /// </summary>
        /// <value>
        /// The row count.
        /// </value>
        public virtual int RowCount { get; }

        /// <summary>
        /// Gets the column count.
        /// </summary>
        /// <value>
        /// The column count.
        /// </value>
        public virtual int ColumnCount { get; }

        /// <summary>
        /// Gets or sets the <see cref="T"/> with the specified i.
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// </exception>
        public virtual T this[int i, int j]
        {
            get
            {
                try
                {
                    return this.array[i, j];
                }
                catch (IndexOutOfRangeException e)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(this.array)}", e);
                }
            }

            set
            {
                try
                {
                    this.array[i, j] = value;
                    this.OnMatrixChanged(new MatrixChangedEventArgs<T> { I = i, J = j, Value = value });
                }
                catch (IndexOutOfRangeException e)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(this.array)}", e);
                }
            }
        }

        /// <summary>
        /// Converts to array.
        /// </summary>
        /// <returns>The array</returns>
        public T[,] ToArray() => this.array.Clone() as T[,];

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(Matrix<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            if (this.GetType() != other.GetType()) return false;

            if (this.RowCount != other.RowCount || this.ColumnCount != other.ColumnCount)
            {
                return false;
            }

            for (int i = 0; i < this.RowCount; i++)
            {
                for (int j = 0; j < this.ColumnCount; j++)
                {
                    if (Comparer<T>.Default.Compare(this[i, j], other[i, j]) != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void OnMatrixChanged(MatrixChangedEventArgs<T> args)
        {
            var local = this.MatrixChanged;
            local?.Invoke(this, args);
        }
    }
}
