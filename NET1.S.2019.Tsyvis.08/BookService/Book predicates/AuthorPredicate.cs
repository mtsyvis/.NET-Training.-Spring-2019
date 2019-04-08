using System;
using BookService.Entities;
using BookService.Interfaces;

namespace BookService.Book_predicates
{
    /// <summary>
    /// Implement <see cref="IPredicate"/>
    /// </summary>
    /// <seealso cref="BookService.Interfaces.IPredicate" />
    public class AuthorPredicate : IPredicate
    {
        /// <summary>
        /// The author
        /// </summary>
        private readonly string author;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorPredicate"/> class.
        /// </summary>
        /// <param name="author">The author.</param>
        /// <exception cref="ArgumentNullException">author is null</exception>
        public AuthorPredicate(string author)
        {
            this.author = author ?? throw new ArgumentNullException($"author is null{nameof(author)}");
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
            if (book?.Author is null)
            {
                return false;
            }

            return book.Author == this.author;
        }
    }
}
