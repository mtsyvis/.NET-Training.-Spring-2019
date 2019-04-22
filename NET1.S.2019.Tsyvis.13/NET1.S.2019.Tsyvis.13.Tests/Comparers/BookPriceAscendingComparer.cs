using System.Collections.Generic;
using NET1.S._2019.Tsyvis._13.Tests.EntitiesForTest;

namespace NET1.S._2019.Tsyvis._13.Tests.Comparers
{
    public class BookPriceAscendingComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
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

            return (int)(x.Price - y.Price);
        }
    }
}
