using System;
using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._03
{
    public static class MathExtensions
    {
        public static double FindNthRoot(double number, int power, double accuracy)
        {
            double xPre = 1;
            double xK = 0.0d;
            double subtraction = double.MaxValue;

            while (subtraction > accuracy)
            {
                xK = ((number - 1.0) * xPre + number / Math.Pow(xPre, number - 1)) / number;
                subtraction = Math.Abs(xK - xPre);
                xPre = xK;
            }

            return xK;
        }

        /// <summary>
        /// Takes a positive integer and returns the nearest greatest integer consisting
        /// of the digits of the source number, and null if no such number exists.
        /// </summary>
        /// <param name="number">The positive integer number to finding</param>
        /// <returns>The nearest greatest integer or null</returns>
        /// <exception cref="ArgumentException">the number is negative or equals zero</exception>
        public static int? NextBiggerThan(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException($"The number is negative or equals zero {nameof(number)}");
            }

            if (number == int.MaxValue)
            {
                return null;
            }

            char[] numbers = number.ToString().ToCharArray();
            int swapPos1 = -1;

            for (int i = numbers.Length - 2; i >= 0; i--)
            {
                if (numbers[i] < numbers[i + 1])
                {
                    swapPos1 = i;
                    break;
                }
            }

            if (swapPos1 == -1)
            {
                return null;
            }

            int swapPos2 = -1;
            char biggerThenSwap = '9';

            for (int i = swapPos1 + 1; i < numbers.Length; i++)
            {
                if (numbers[i] > numbers[swapPos1] && numbers[i] < biggerThenSwap)
                {
                    biggerThenSwap = numbers[i];
                    swapPos2 = i;
                }
            }

            numbers.SwapByIndexes(swapPos1, swapPos2);
            Array.Sort(numbers, swapPos1 + 1, numbers.Length - swapPos1 - 1);

            return int.Parse(new string(numbers));
        }

        private static void SwapByIndexes(this char[] array, int firstIndex, int secondIndex)
        {
            char temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }
    }
}
