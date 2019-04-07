using System.Collections.Generic;

namespace BookService
{
    /// <summary>
    /// Defines methods that class implements to load and save books.
    /// </summary>
    public interface IBookListStorage
    {
        /// <summary>
        /// Load books from storage.
        /// </summary>
        /// <returns>saved books</returns>
        IEnumerable<Book> Load();

        /// <summary>
        /// Save book in storage.
        /// </summary>
        /// <param name="books">books to saving</param>
        void Save(IEnumerable<Book> books);
    }
}
