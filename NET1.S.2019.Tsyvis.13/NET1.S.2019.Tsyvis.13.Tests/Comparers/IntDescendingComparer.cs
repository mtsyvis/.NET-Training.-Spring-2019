using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._13.Tests.Comparers
{
    public class IntDescendingComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y - x;
        }
    }
}
