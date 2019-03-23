using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET1.S._2019.Tsyvis._02
{
    /// <summary>
    /// Provide method that manipulate bits.
    /// </summary>
    public static class BitManipulations
    {
        /// <summary>
        /// Insert the first bits of the second number into the first so that 
        /// the bits of the second number occupy positions from bit i to bit j.
        /// </summary>
        /// <param name="numberSource">The number to insert bits.</param>
        /// <param name="numberIn">The number for insert.</param>
        /// <param name="i">The start index for insert.</param>
        /// <param name="j">The last index for insert.</param>
        /// <returns>The number after inserting bits.</returns>
        /// <exception cref="ArgumentOutOfRangeException">start index and last index must be greater then 0 and less then 32.
        /// And start index nust be greater then last index.</exception>
        public static int InsertNumber(int numberSource, int numberIn, int i, int j)
        {
            if (i < 0 || j < 0 || i > 31 || j > 31 || i > j)
            {
                throw new ArgumentOutOfRangeException($"Start index and last index must be greater then 0 and less then 32. And start index nust be greater then last index. {nameof(i)} {nameof(j)}");
            }

            int result = numberSource;
            int size = sizeof(int) * 8 - 1;

            for (int k = j - i + 1; k < size; k++)
            {
                int setZero = 1 << k;
                numberIn = numberIn & ~setZero;
            }

            int temp = numberIn << i;
            result = temp | result;

            temp = numberSource >> j;
            temp = temp << j;

            result = result | temp;
            return result;
        }
    }
}
