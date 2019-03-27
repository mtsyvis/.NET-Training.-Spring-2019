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
        /// <summary>
        /// Find gcd by Euclidean alghoritm
        /// </summary>
        /// <param name="time">The time during which the method is executed</param>
        /// <param name="array">The array of numbers whose gcd must be found</param>
        /// <returns>GCD</returns>
        /// <exception cref="ArgumentException">length of array is 0 or 1</exception>
        public static int GCDEuclideanCalculation(out long time, params int[] array)
        {
            if (array.Length <= 1)
            {
                throw new ArgumentException($"length of array is 0 or 1{nameof(array.Length)}");
            }

            var watch = System.Diagnostics.Stopwatch.StartNew();
            int gcd = array[0];

            for(int i = 1; i < array.Length; i++)
            {
                if(array[i] == 0)
                {
                    continue;
                }
                gcd = FindingGCDByEuclidean(gcd, array[i]);
            }

            watch.Stop();
            time = watch.ElapsedMilliseconds;
            return gcd;
        }

        /// <summary>
        /// Find gcd by binary Euclidean alghoritm
        /// </summary>
        /// <param name="time">The time during which the method is executed</param>
        /// <param name="array">The array of numbers whose gcd must be found</param>
        /// <returns>The tuple with the running time of the method and gcd number</returns>
        /// <exception cref="ArgumentException">length of array is 0 or 1</exception>
        public static (int gcd, long time) GCDBinaryEuclideanCalculation(params int[] array)
        {
            if (array.Length <= 1)
            {
                throw new ArgumentException($"length of array is 0 or 1{nameof(array.Length)}");
            }

            var watch = System.Diagnostics.Stopwatch.StartNew();
            int gcd = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                gcd = FindingGCDByEuclidean(gcd, array[i]);
            }

            watch.Stop();                 
            return (gcd, watch.ElapsedMilliseconds);
        }

        #region Private methods
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
            if (a == 0)
            {
                return b;
            }
            if (b == 0)
            {
                return a;
            }
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
