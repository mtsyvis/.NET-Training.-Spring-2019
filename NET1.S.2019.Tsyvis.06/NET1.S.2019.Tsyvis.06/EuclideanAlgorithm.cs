using System;

namespace NET1.S._2019.Tsyvis._06
{
    /// <summary>
    /// Realizes finding gcd by the binary Euclidean (Stein) method.
    /// </summary>
    internal class EuclideanAlgorithm : GCDAlgorithm
    {
        protected override int Gcd(int a, int b)
        {
            if (b == 0)
            {
                return Math.Abs(a);
            }

            return Gcd(b, a % b);
        }
    }
}

