using System;
using NUnit.Framework;
using BookService;
using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._08.Tests
{
    using BookService.Book_comparers;

    [TestFixture]
    public class BookListServiceTests
    {
        private readonly IEnumerable<Book> books = new FakeBookListStorage().Load();

        [Test]
        public void GetBooksTest()
        {
            var service = new BookListService(new FakeBookListStorage());

            Assert.AreEqual(this.books, service.Books);
        }

        [Test]
        public void SaveAndAddBooksTest()
        {
            var service = new BookListService(new FakeBookListStorage());
            var expectedBooks = new List<Book>(this.books);
            var book = new Book("124143", "Bart de Smet", "C# 4.0 Unleashed", "Minsk", 2011, 300, 30);
            expectedBooks.Add(book);

            service.Add(book);

            Assert.AreEqual(expectedBooks, service.Books);
        }

        [Test]
        public void RemoveBooksTest()
        {
            var service = new BookListService(new FakeBookListStorage());
            var expectedBooks = new List<Book>(this.books);

            var book = expectedBooks[0];

            expectedBooks.Remove(book);
            service.Remove(book);

            Assert.AreEqual(expectedBooks, service.Books);
        }

        [Test]
        public void FindByTag_ByAuthor_WellFinding()
        {
            var service = new BookListService(new FakeBookListStorage());
            var book = new Book("124143", "Bart de Smet", "C# 4.0 Unleashed", "Minsk", 2011, 300, 30);
            service.Add(book);
            string author = book.Author;

            IEnumerable<Book> expectedBooks = new Book[] { book };

            Assert.AreEqual(expectedBooks, service.FindByTag(author));
        }

        [Test]
        public void Sort_DefaultComparer_WellSorted()
        {
            var service = new BookListService(new FakeBookListStorage());

            IEnumerable<Book> expectedBooks = new Book[]
                                                  {
                                                      new Book(
                                                          "1234923400",
                                                          "Lisa Wingate",
                                                          "Before We Were Yours",
                                                          "Minsk",
                                                          2017,
                                                          220,
                                                          18),
                                                      new Book(
                                                          "1412452883",
                                                          "Mark Manson",
                                                          "The Subtle Art of Not Giving a F*ck",
                                                          "Minsk",
                                                          2016,
                                                          120,
                                                          17),
                                                      new Book(
                                                          "9999999992",
                                                          "Delia Owens",
                                                          "Where the Crawdads Sing",
                                                          "Minsk",
                                                          2018,
                                                          234,
                                                          15.40)
                                                  };
            service.Sort();

            Assert.AreEqual(expectedBooks, service.Books);
        }

        [Test]
        public void Sort_BookPriceAscendingComparer_WellSorted()
        {
            var service = new BookListService(new FakeBookListStorage());

            IEnumerable<Book> expectedBooks = new Book[]
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

            service.Sort(new BookPriceAscendingComparer());

            Assert.AreEqual(expectedBooks, service.Books);
        }

        [Test]
        public void Remove_BookIsNotStored_ThrowArgumentException()
        {
            var service = new BookListService(new FakeBookListStorage());
            var book = new Book("124143", "Bart de Smet", "C# 4.0 Unleashed", "Minsk", 2011, 300, 30);

            Assert.Throws<ArgumentException>(() => service.Remove(book));
        }

        [Test]
        public void Add_BookIsAlreadyStored_ThrowArgumentException()
        {
            var service = new BookListService(new FakeBookListStorage());
            var bookList = new List<Book>(this.books);
            var book = bookList[0];

            Assert.Throws<ArgumentException>(() => service.Add(book));
        }
    }
}
