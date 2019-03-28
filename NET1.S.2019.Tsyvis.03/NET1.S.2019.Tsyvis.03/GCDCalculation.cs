using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET1.S._2019.Tsyvis._03
{
    /// <summary>
    /// Provide GCD calculation by various algorithms.
    /// </summary>
    public static class GCDCalculation
    {
        #region Finding GCD by Euclidean alghoritm
        /// <summary>
        /// Find gcd by Euclidean alghoritm for many numbers
        /// </summary>
        /// <param name="time">The time during which the method is executed</param>
        /// <param name="array">The array of numbers whose gcd must be found</param>
        /// <returns>GCD</returns>
        /// <exception cref="ArgumentException">length of array is 0 or 1</exception>
        public static int GCDEuclideanCalculation(out long time, params int[] array)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            if (array.Length <= 1)
            {
                throw new ArgumentException($"length of array is 0 or 1{nameof(array.Length)}");
            }

            int gcd = CalculateGCDForManyNumbers(array);
            watch.Stop();
            time = watch.ElapsedMilliseconds;
            return gcd;
        }

        /// <summary>
        /// Find gcd by Euclidean alghoritm for 2 numbers
        /// </summary>
        /// <param name="a">The first number for calculation</param>
        /// <param name="b">The second number for calculation</param>
        /// <param name="time">The time during which the method is executed</param>
        /// <returns>GCD</returns>
        public static int GCDEuclideanCalculation(int a, int b, out long time)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            int gcd = FindingGCDByEuclidean(a, b);
            watch.Stop();
            time = watch.ElapsedMilliseconds;
            return gcd;
        }

        /// <summary>
        /// Find gcd by Euclidean alghoritm for 3 numbers
        /// </summary>
        /// <param name="a">The first number for calculation</param>
        /// <param name="b">The second number for calculation</param>
        /// <param name="c">The third number for calculation</param>
        /// <param name="time">The time during which the method is executed</param>
        /// <returns>GCD</returns>
        public static int GCDEuclideanCalculation(int a, int b, int c, out long time)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            int gcd = FindingGCDByEuclidean(FindingGCDByEuclidean(a, b), c);
            watch.Stop();
            time = watch.ElapsedMilliseconds;
            return gcd;
        }
        #endregion

        #region Finding GCD by binary Euclidean alghoritm
        /// <summary>
        /// Find gcd by binary Euclidean alghoritm for many numbers
        /// </summary>
        /// <param name="time">The time during which the method is executed</param>
        /// <param name="array">The array of numbers whose gcd must be found</param>
        /// <returns>The tuple with the running time of the method and gcd number</returns>
        /// <exception cref="ArgumentException">length of array is 0 or 1</exception>
        public static (int gcd, long time) GCDBinaryEuclideanCalculation(params int[] array)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            if (array.Length <= 1)
            {
                throw new ArgumentException($"length of array is 0 or 1{nameof(array.Length)}");
            }

            int gcd = CalculateGCDForManyNumbers(array);
            watch.Stop();                 
            return (gcd, watch.ElapsedMilliseconds);
        }

        /// <summary>
        /// Find gcd by binary Euclidean alghoritm for 2 numbers
        /// </summary>
        /// <param name="a">The first number for calculation</param>
        /// <param name="b">The second number for calculation</param>
        /// <param name="time">The time during which the method is executed</param>
        /// <returns>GCD</returns>
        public static (int gcd, long time) GCDBinaryEuclideanCalculation(int a, int b)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            int gcd = FindingGCDByBinaryEuclidean(a, b);
            watch.Stop();
            return (gcd, watch.ElapsedMilliseconds);
        }

        /// <summary>
        /// Find gcd by binary Euclidean alghoritm for 3 numbers
        /// </summary>
        /// <param name="a">The first number for calculation</param>
        /// <param name="b">The second number for calculation</param>
        /// <param name="c">The third number for calculation</param>
        /// <param name="time">The time during which the method is executed</param>
        /// <returns>GCD</returns>
        public static (int gcd, long time) GCDBinaryEuclideanCalculation(int a, int b, int c)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            int gcd = FindingGCDByBinaryEuclidean(FindingGCDByBinaryEuclidean(a, b), c);
            watch.Stop();
            return (gcd, watch.ElapsedMilliseconds);
        }
        #endregion

        #region Private methods
        private static int CalculateGCDForManyNumbers(params int[] array)
        {
            int gcd = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == 0)
                {
                    continue;
                }
                gcd = FindingGCDByEuclidean(gcd, array[i]);
            }

            return gcd;
        }

        private static int FindingGCDByEuclidean(int a, int b)
        {
            if (b == 0)
            {
                return Math.Abs(a);
            }

            return FindingGCDByEuclidean(b, a % b);
        }

        private static int FindingGCDByBinaryEuclidean(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            int gcd = 1;
            int tmp = 0;
            if (a == b)
            {
                return a;
            }
            if (a == 1 || b == 1)
            {
                return 1;
            }
            while (a != 0 && b != 0)
            {
                if (a % 2 == 0 && b % 2 == 0)
                {
                    gcd *= 2;
                    a /= 2;
                    b /= 2;
                    continue;
                }
                if (a % 2 == 0 && b % 2 != 0)
                {
                    a /= 2;
                    continue;
                }
                if (b % 2 == 0 && a % 2 != 0)
                {
                    b /= 2;
                    continue;
                }
                if (a > b)
                {
                    tmp = a;
                    a = b;
                    b = tmp;
                }
                tmp = a;
                a = (b - a) / 2;
                b = tmp;
            }
            if (a == 0)
            {
                return gcd * b;
            }
            else
            {
                return gcd * a;
            }
        }
        #endregion
    }
}
