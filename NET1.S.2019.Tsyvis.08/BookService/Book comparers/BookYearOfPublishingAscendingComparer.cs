﻿using System.Collections.Generic;

namespace BookService.Book_comparers
{
    /// <summary>
    /// Provide comparing two books by year of publishing.
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IComparer{BookService.Book}" />
    public class BookYearOfPublishingAscendingComparer : IComparer<Book>
    {
        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>
        /// A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table.Value Meaning Less than zero
        /// <paramref name="x" /> is less than <paramref name="y" />.Zero
        /// <paramref name="x" /> equals <paramref name="y" />.Greater than zero
        /// <paramref name="x" /> is greater than <paramref name="y" />.
        /// </returns>
        public int Compare(Book x, Book y)
        {
            return x.YearOfPublishing.CompareTo(y.YearOfPublishing);
        }
    }
}
