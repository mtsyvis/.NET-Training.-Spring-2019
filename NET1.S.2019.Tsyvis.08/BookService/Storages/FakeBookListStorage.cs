using System.Collections.Generic;
using BookService.Interfaces;
using BookService.Entities;

namespace BookService.Storages
{
    /// <summary>
    /// Provide saving and loading books.
    /// </summary>
    /// <seealso cref="BookService.IBookListStorage" />
    public class FakeBookListStorage : IBookListStorage
    {
        /// <summary>
        /// The books
        /// </summary>
        private static IEnumerable<Book> storedBooks = new Book[]
                                              {
                                                  new Book(
                                                      "9999999992",
                                                      "Delia Owens",
                                                      "Where the Crawdads Sing",
                                                      "Minsk",
                                                      2018,
                                                      234,
                                                      15.40),
                                                  new Book(
                                                      "1412452883",
                                                      "Mark Manson",
                                                      "The Subtle Art of Not Giving a F*ck",
                                                      "Minsk",
                                                      2016,
                                                      120,
                                                      17),
                                                  new Book(
                                                      "1234923400",
                                                      "Lisa Wingate",
                                                      "Before We Were Yours",
                                                      "Minsk",
                                                      2017,
                                                      220,
                                                      18)
                                              };

        /// <summary>
        /// Load books from storage.
        /// </summary>
        /// <returns>
        /// saved books
        /// </returns>
        public IEnumerable<Book> Load()
        {
            return storedBooks;
        }

        /// <summary>
        /// Save book in storage.
        /// </summary>
        /// <param name="books">books to saving</param>
        public void Save(IEnumerable<Book> books)
        {
            storedBooks = books;
        }
    }
}
