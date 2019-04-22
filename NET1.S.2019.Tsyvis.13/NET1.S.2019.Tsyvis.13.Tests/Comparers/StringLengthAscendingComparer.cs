using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._13.Tests.Comparers
{
    public class StringLengthAscendingComparer : IComparer<string>
    {
        public int Compare(string x, string y)
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

            return x.Length - y.Length;
        }
    }
}
