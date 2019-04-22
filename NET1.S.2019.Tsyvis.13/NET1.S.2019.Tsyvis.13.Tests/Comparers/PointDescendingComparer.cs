using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._13.Tests.Comparers
{
    public class PointDescendingComparer : IComparer<BinarySearchTreeTests.Point>
    {
        public int Compare(BinarySearchTreeTests.Point first, BinarySearchTreeTests.Point second)
        {
            int order = second.x - first.x;
            if (order != 0)
            {
                return order;
            }

            return second.y - first.y;
        }
    }
}
