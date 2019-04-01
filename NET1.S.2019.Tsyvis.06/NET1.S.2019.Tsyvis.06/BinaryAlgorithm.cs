using System;

namespace NET1.S._2019.Tsyvis._06
{
    /// <summary>
    /// Realizes finding gcd by the Euclidean method.
    /// </summary>
    internal class BinaryAlgorithm : GCDAlgorithm
    {
        protected override int Gcd(int a, int b)
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
    }
}

