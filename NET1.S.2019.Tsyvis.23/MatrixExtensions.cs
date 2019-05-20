using NET1.S._2019.Tsyvis._23.Matrices;
using NET1.S._2019.Tsyvis._23.Visitors;

namespace NET1.S._2019.Tsyvis._23
{
    /// <summary>
    /// Provide addition matrix.
    /// </summary>
    public static class MatrixExtensions
    {
        /// <summary>
        /// Additions the specified another matrix.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix">The matrix.</param>
        /// <param name="anotherMatrix">Another matrix.</param>
        /// <returns>Added matrix</returns>
        public static Matrix<T> Addition<T>(this Matrix<T> matrix, Matrix<T> anotherMatrix)
            where T : struct
        {
            var visitor = new MatrixAdditionVisitor<T>();
            return visitor.DynamicVisit(matrix, anotherMatrix);
        }
    }
}
