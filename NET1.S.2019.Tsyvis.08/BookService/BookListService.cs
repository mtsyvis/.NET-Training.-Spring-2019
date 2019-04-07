using System;
using System.Collections.Generic;

namespace BookService
{
    /// <summary>
    /// Provide manipulation with books.
    /// </summary>
    public class BookListService
    {
        /// <summary>
        /// storage of books.
        /// </summary>
        private IBookListStorage bookListStorage;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storage"></param>
        public BookListService(IBookListStorage storage)
        {
            this.bookListStorage = storage ?? throw new ArgumentNullException($"storage is null{nameof(storage)}");
            this.Load();
        }

        /// <summary>
        /// Gets books
        /// </summary>
        public List<Book> Books { get; private set; }

        /// <summary>
        /// Load book from storage.
        /// </summary>
        public void Load()
        {
            this.Books = new List<Book>(this.bookListStorage.Load());
        }

        /// <summary>
        /// Saved book in storage.
        /// </summary>
        public void Save()
        {
            this.bookListStorage.Save(this.Books);
        }

        /// <summary>
        /// Add book to storage.
        /// </summary>
        /// <param name="book">The book</param>
        public void Add(Book book)
        {
            if (this.Books.Contains(book))
            {
                throw new ArgumentException($"this book already stored{nameof(book)}");
            }

            this.Books.Add(book);
            this.Save();
        }

        /// <summary>
        /// Remove book from storage.
        /// </summary>
        /// <param name="book">The book</param>
        public void Remove(Book book)
        {
            if (!this.Books.Contains(book))
            {
                throw new ArgumentException($"this book is not kept{nameof(book)}");
            }

            this.Books.Remove(book);
            this.Save();
        }

        /// <summary>
        /// Find books by author.
        /// </summary>
        /// <param name="author">The author</param>
        /// <returns>founded books</returns>
        public IEnumerable<Book> FindByTag(string author)
        {
            var foundBooks = new List<Book>();
            foreach (var book in this.Books)
            {
                if (book.Author == author)
                {
                    foundBooks.Add(book);
                }
            }

            return foundBooks;
        }

        /// <summary>
        /// Find books by year of publishing.
        /// </summary>
        /// <param name="author">The year of publishing</param>
        /// <returns>founded books</returns>
        public IEnumerable<Book> FindByTag(int yearOfPublishing)
        {
            var foundBooks = new List<Book>();
            foreach (var book in this.Books)
            {
                if (book.YearOfPublishing == yearOfPublishing)
                {
                    foundBooks.Add(book);
                }
            }

            return foundBooks;
        }

        /// <summary>
        /// Sort books using the default comparer.
        /// </summary>
        public void Sort()
        {
            this.Books.Sort();
        }

        /// <summary>
        /// Sort books using comparer.
        /// </summary>
        /// <param name="comparer">The comparer to sorting.</param>
        /// <exception cref="ArgumentNullException">comparer is null</exception>
        public void Sort(IComparer<Book> comparer)
        {
            if (comparer is null)
            {
                throw new ArgumentNullException($"comparer is null{nameof(comparer)}");
            }

            this.Books.Sort(comparer);
        }
    }
}
