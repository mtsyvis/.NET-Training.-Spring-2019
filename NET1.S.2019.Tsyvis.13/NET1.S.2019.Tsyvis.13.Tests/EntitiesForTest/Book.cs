using System;

namespace NET1.S._2019.Tsyvis._13.Tests.EntitiesForTest
{
    /// <summary>
    /// Entity of Book
    /// </summary>
    /// <seealso cref="System.IComparable{Book}" />
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        /// <summary>
        /// Gets or sets the isbn.
        /// </summary>
        /// <value>
        /// The isbn.
        /// </value>
        public string ISBN { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public double Price { get; set; }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="other" /> in the sort order.  Zero This instance occurs in the same position in the sort order as <paramref name="other" />. Greater than zero This instance follows <paramref name="other" /> in the sort order.
        /// </returns>
        /// <exception cref="ArgumentNullException">Unable to compare two books</exception>
        public int CompareTo(Book other)
        {
            if (other is null)
            {
                throw new ArgumentNullException($"Unable to compare two books{nameof(other)}");
            }

            return string.Compare(this.Title, other.Title);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(Book other)
        {
            if (other is null)
            {
                return false;
            }

            return this.ISBN == other.ISBN && Math.Abs(this.Price - other.Price) < 0.000001 && this.Title == other.Title;
        }
    }
}
