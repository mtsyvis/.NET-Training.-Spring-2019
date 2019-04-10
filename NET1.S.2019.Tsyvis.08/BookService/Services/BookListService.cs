using System;
using System.Collections.Generic;
using BookService.Entities;
using BookService.Interfaces;

namespace BookService.Services
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
        /// Initializes a new instance of the <see cref="BookListService"/> class.
        /// </summary>
        /// <param name="storage">The storage.</param>
        /// <exception cref="ArgumentNullException">storage is null</exception>
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
            //this.Books = (List<Book>)this.bookListStorage.Load();
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
        /// Remove book from storage.
        /// </summary>
        /// <param name="book">The book</param>
        public void Remove(string isbn)
        {
            if (isbn is null)
            {
                throw new ArgumentNullException($"isbn is null{nameof(isbn)}");
            }

            var book = this.FindByTag(isbn);
            this.Books.Remove(book);
            this.Save();
        }

        /// <summary>
        /// Finds the by tag.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>founded books</returns>
        /// <exception cref="ArgumentNullException">predicate is null</exception>
        public IEnumerable<Book> FindByTag(IPredicate predicate)
        {
            if (predicate is null)
            {
                throw new ArgumentNullException($"predicate is null {nameof(predicate)}");
            }

            var foundBooks = new List<Book>() { };
            foreach (var book in this.Books)
            {
                if (predicate.IsMatched(book))
                {
                    foundBooks.Add(book);
                }
            }

            return foundBooks;
        }

        /// <summary>
        /// Finds the by tag.
        /// </summary>
        /// <param name="isbn">The isbn.</param>
        /// <returns>founded book</returns>
        /// <exception cref="System.ArgumentNullException">isbn is null</exception>
        public Book FindByTag(string isbn)
        {
            if (isbn is null)
            {
                throw new ArgumentNullException($"isbn is null {nameof(isbn)}");
            }

            foreach (var book in this.Books)
            {
                if (book.ISBN.Equals(isbn))
                {
                    return book;
                }
            }

            return null;
        }

        /// <summary>
        /// Updates the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <param name="isbn">The isbn.</param>
        /// <exception cref="ArgumentNullException">
        /// isbn is null
        /// or
        /// book is null
        /// </exception>
        /// <exception cref="ArgumentException">this book already stored</exception>
        public void UpdateBook(Book book, string isbn)
        {
            if (isbn is null)
            {
                throw new ArgumentNullException($"isbn is null{nameof(book)}");
            }

            if (book is null)
            {
                throw new ArgumentNullException($"book is null{nameof(book)}");
            }

            if (this.Books.Contains(book))
            {
                throw new ArgumentException($"this book already stored{nameof(book)}");
            }

            for (int i = 0; i < this.Books.Count; i++)
            {
                if (this.Books[i].ISBN.Equals(book.ISBN))
                {
                    this.Books[i] = book;
                }
            }

            this.Save();
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
