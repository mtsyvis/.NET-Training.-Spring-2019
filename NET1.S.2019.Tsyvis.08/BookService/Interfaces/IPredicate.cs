using BookService.Entities;

namespace BookService.Interfaces
{
    /// <summary>
    /// Checked condition of book.
    /// </summary>
    public interface IPredicate
    {
        /// <summary>
        /// Determines whether the specified book is matched.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>
        ///   <c>true</c> if the specified book is matched; otherwise, <c>false</c>.
        /// </returns>
        bool IsMatched(Book book);
    }
}
