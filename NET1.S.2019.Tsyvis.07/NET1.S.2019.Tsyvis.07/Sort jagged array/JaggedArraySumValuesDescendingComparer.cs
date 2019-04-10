using System;
using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._07.Sort_jagged_array
{
    /// <summary>
    /// Provide sorted jugged array.
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IComparer{System.Int32[]}" />
    public class JaggedArraySumValuesDescendingComparer : IComparer<int[]>
    {
        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>
        /// A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table.Value Meaning Less than zero
        /// <paramref name="x" /> is less than <paramref name="y" />.Zero
        /// <paramref name="x" /> equals <paramref name="y" />.Greater than zero
        /// <paramref name="x" /> is greater than <paramref name="y" />.
        /// </returns>
        public int Compare(int[] x, int[] y)
        {
            if (x is null && y is null)
            {
                return 0;
            }

            if (x is null)
            {
                return -1;
            }

            if (y is null)
            {
                return 1;
            }

            return this.SumValues(y) - this.SumValues(x);
        }

        private int SumValues(int[] array)
        {
            int sum = 0;
            foreach (var i in array)
            {
                sum += i;
            }

            return sum;
        }
    }
}
