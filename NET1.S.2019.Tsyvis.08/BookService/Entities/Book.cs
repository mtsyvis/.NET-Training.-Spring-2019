using System;

namespace BookService.Entities
{
    /// <summary>
    /// Entity of book.
    /// </summary>
    /// <seealso cref="System.IEquatable{BookService.Entities.Book}" />
    /// <seealso cref="System.IComparable{BookService.Entities.Book}" />
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="ISBN">The isbn.</param>
        /// <param name="author">The author.</param>
        /// <param name="title">The title.</param>
        /// <param name="publishingHouse">The publishing house.</param>
        /// <param name="yearOfPublishing">The year of publishing.</param>
        /// <param name="numberOfPages">The number of pages.</param>
        /// <param name="price">The price.</param>
        public Book(
            string ISBN,
            string author,
            string title,
            string publishingHouse,
            int yearOfPublishing,
            int numberOfPages,
            double price)
        {
            this.ISBN = ISBN;
            this.Author = author;
            this.Title = title;
            this.PublishingHouse = publishingHouse;
            this.YearOfPublishing = yearOfPublishing;
            this.NumberOfPages = numberOfPages;
            this.Price = price;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        public Book() { }

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
        /// Gets or sets the publishing house.
        /// </summary>
        /// <value>
        /// The publishing house.
        /// </value>
        public string PublishingHouse { get; set; }

        /// <summary>
        /// Gets or sets the year of publishing.
        /// </summary>
        /// <value>
        /// The year of publishing.
        /// </value>
        public int YearOfPublishing { get; set; }

        /// <summary>
        /// Gets or sets the number of pages.
        /// </summary>
        /// <value>
        /// The number of pages.
        /// </value>
        public int NumberOfPages { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public double Price { get; set; }

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

            if (this.ISBN != other.ISBN || this.Author != other.Author || this.NumberOfPages != other.NumberOfPages
                || this.Price != other.Price || this.PublishingHouse != other.PublishingHouse
                || this.Title != other.Title || this.YearOfPublishing != other.YearOfPublishing)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            int hashCode = YearOfPublishing.GetHashCode();
            hashCode += this.ISBN.GetHashCode();
            hashCode += this.NumberOfPages.GetHashCode();
            hashCode += this.Author.GetHashCode();
            hashCode += this.Title.GetHashCode();
            return hashCode;
        }

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

            return this.Title.CompareTo(other.Title);
        }
    }
}
