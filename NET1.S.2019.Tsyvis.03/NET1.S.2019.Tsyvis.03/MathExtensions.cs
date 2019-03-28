using System;
using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._03
{
    /// <summary>
    /// Provide methods for manipulation with numbers.
    /// </summary>
    public static class MathExtensions
    {
        /// <summary>
        /// Allows to calculate the nth degree root from a real number a by the Newton method with a given accuracy.
        /// </summary>
        /// <param name="number">The number for calculation</param>
        /// <param name="power">The power for calculation</param>
        /// <param name="accuracy">The accuracy for calculation</param>
        /// <returns>Nth root</returns>
        /// <exception cref="ArgumentException">power or accuracy is less then 0. -or- it is 
        /// impossible to take the root of an even degree from a negative number</exception>
        public static double FindNthRoot(double number, int power, double accuracy)
        {
            if(power < 0 || accuracy < 0)
            {
                throw new ArgumentException($"power or accuracy is less then 0 {nameof(power)} {nameof(accuracy)}");
            }

            if (power % 2 == 0 && number < 0) 
            {
                throw new ArgumentException($"it is impossible to take the root of an even degree from a negative number {nameof(power)} {nameof(number)}");
            }

            double xPre = 1, xK = 0.0d;
            double subtraction = accuracy + 1;

            while (subtraction >= accuracy)
            {
                xK = ((power - 1.0) * xPre + number / Math.Pow(xPre, (power - 1))) / power;
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
