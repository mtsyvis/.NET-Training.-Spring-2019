using System;

namespace NET1.S._2019.Tsyvis._06
{
    /// <summary>
    /// Provide finding gcd.
    /// </summary>
    internal abstract class GCDAlgorithm
    {
        /// <summary>
        /// Find gcd for 2 numbers.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number</param>
        /// <returns>found gcd</returns>
        /// <exception cref="ArgumentException">arguments cannot be 0</exception>
        public int Calculate(int a, int b)
        {
            if (a == 0 || b == 0)
            {
                throw new ArgumentException($"arguments cannot be 0{nameof(a)} {nameof(b)}");
            }

            return Gcd(a, b);
        }

        /// <summary>
        /// Find gcd for 2 numbers and calculate time during which the method is executed.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number</param>
        /// <param name="millesecond">The time during which the method is executed</param>
        /// <returns>found gcd</returns>
        /// <exception cref="ArgumentException">arguments cannot be 0</exception>
        public int Calculate(int a, int b, out long millesecond)
        {
            if (a == 0 || b == 0)
            {
                throw new ArgumentException($"arguments cannot be 0{nameof(a)} {nameof(b)}");
            }

            var watch = System.Diagnostics.Stopwatch.StartNew();
            int gcd = Gcd(a, b);
            watch.Stop();
            millesecond = watch.ElapsedMilliseconds;
            return gcd;
        }

        /// <summary>
        /// Find gcd for 3 numbers.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="c">The third number.</param>
        /// <returns>found gcd</returns>
        /// <exception cref="ArgumentException">arguments cannot be 0</exception>
        public int Calculate(int a, int b, int c)
        {
            if (a == 0 || b == 0 || c == 0)
            {
                throw new ArgumentException($"arguments cannot be 0{nameof(a)} {nameof(b)} {nameof(c)}");
            }

            return Gcd(Gcd(a, b), c);
        }

        /// <summary>
        /// Find gcd for 3 numbers and calculate time during which the method is executed.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="c">The third number.</param>
        /// <param name="millesecond">The time during which the method is executed</param>
        /// <returns>found gcd</returns>
        /// <exception cref="ArgumentException">arguments cannot be 0</exception>
        public int Calculate(int a, int b, int c, out long millesecond)
        {
            if (a == 0 || b == 0 || c == 0)
            {
                throw new ArgumentException($"arguments cannot be 0{nameof(a)} {nameof(b)} {nameof(c)}");
            }

            var watch = System.Diagnostics.Stopwatch.StartNew();
            int gcd = Gcd(Gcd(a, b), c);
            watch.Stop();
            millesecond = watch.ElapsedMilliseconds;
            return gcd;
        }

        /// <summary>
        /// Find gcd for many numbers.
        /// </summary>
        /// <param name="array">The array of numbers whose gcd must be found</param>
        /// <returns>found gcd</returns>
        public int Calculate(int[] array)
        {
            CheckArrayForZeroValues(array);

            return GcdForManyParams(array);
        }

        /// <summary>
        /// Find gcd for many numbers and calculate time during which the method is executed.
        /// </summary>
        /// <param name="millesecond">The time during which the method is executed</param>
        /// <param name="array">The array of numbers whose gcd must be found</param>
        /// <returns>found gcd</returns>
        /// <exception cref="ArgumentException">all array elements are 0</exception>
        /// <exception cref="ArgumentNullException">array is null</exception>
        public int Calculate(int[] array, out long millesecond)
        {
            CheckArrayForZeroValues(array);

            var watch = System.Diagnostics.Stopwatch.StartNew();
            int gcd = GcdForManyParams(array);
            watch.Stop();
            millesecond = watch.ElapsedMilliseconds;
            return gcd;
        }

        /// <summary>
        /// Method that must be overrided to finding gcd needed ways.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>found gcd</returns>
        protected abstract int Gcd(int a, int b);

        private void CheckArrayForZeroValues(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"array is null{nameof(array)}");
            }

            int count = 0;
            foreach (var i in array)
            {
                if (i == 0)
                {
                    count++;
                }
            }

            if (count == array.Length)
            {
                throw new ArgumentException($"all array elements are 0 {nameof(array)}");
            }
        }

        private int GcdForManyParams(int[] array)
        {
            int gcd = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == 0)
                {
                    continue;
                }

                gcd = this.Gcd(gcd, array[i]);
            }

            return gcd;
        }
    }
}

