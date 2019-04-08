using BookService.Interfaces;
using BookService.Entities;

namespace BookService.Book_predicates
{
    /// <summary>
    /// Implement <see cref="IPredicate"/>
    /// </summary>
    /// <seealso cref="BookService.Interfaces.IPredicate" />
    public class YearOfPublishingPredicate : IPredicate
    {
        /// <summary>
        /// The year of publishing
        /// </summary>
        private readonly int yearOfPublishing;

        /// <summary>
        /// Initializes a new instance of the <see cref="YearOfPublishingPredicate"/> class.
        /// </summary>
        /// <param name="yearOfPublishing">The year of publishing.</param>
        public YearOfPublishingPredicate(int yearOfPublishing)
        {
            this.yearOfPublishing = yearOfPublishing;
        }

        /// <summary>
        /// Determines whether the specified book is matched.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>
        ///   <c>true</c> if the specified book is matched; otherwise, <c>false</c>.
        /// </returns>
        public bool IsMatched(Book book)
        {
            if (book is null)
            {
                return false;
            }

            return book.YearOfPublishing == this.yearOfPublishing;
        }
    }
}
