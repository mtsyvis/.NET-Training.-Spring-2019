using System;
using NUnit.Framework;
using BookService.Entities;
using BookService.Storages;
using BookService.Services;
using System.Collections.Generic;
using BookService.Book_comparers;

namespace NET1.S._2019.Tsyvis._08.Tests
{
    using BookService.Book_predicates;

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
        public void FindByTag_AuthorPredicate_WellFinding()
        {
            var service = new BookListService(new FakeBookListStorage());
            var book1 = new Book("124143", "Bart de Smet", "C# 4.0 Unleashed", "Minsk", 2011, 300, 30);
            var book2 = new Book("124143", "Bart de Smet", "C# 5.0 Unleashed", "Piter", 2011, 300, 30);

            service.Add(book1);
            service.Add(book2);
            IEnumerable<Book> expectedBooks = new Book[] { book1, book2 };
            string author = "Bart de Smet";

            Assert.AreEqual(expectedBooks, service.FindByTag(new AuthorPredicate(author)));
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
