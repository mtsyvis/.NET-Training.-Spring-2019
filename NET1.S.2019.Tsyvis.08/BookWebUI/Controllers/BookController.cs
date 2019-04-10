using System.Web.Mvc;
using BookService.Services;
using BookService.Entities;
using BookService.Storages;

namespace BookWebUI.Controllers
{
    public class BookController : Controller
    {
        private BookListService service;

        public BookController()
        {
            this.service = new BookListService(new FakeBookListStorage());
        }

        public ActionResult Index()
        {
            return View(this.service.Books);
        }

        public ActionResult Details(string isbn)
        {
            var findBook = this.service.FindByTag(isbn);

            return this.View(findBook);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                this.service.Add(book);

                return this.RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Error = "This book already saved!";
                return this.View();
            }
        }

        [HttpGet]
        public ActionResult Edit(string isbn)
        {
            var foundedBook = this.service.FindByTag(isbn);

            return this.View(foundedBook);
        }

        [HttpPost]
        public ActionResult Edit(Book book, string isbn)
        {
            try
            {
                this.service.UpdateBook(book, isbn);

                return this.RedirectToAction("Index");
            }
            catch
            {
                return this.View();
            }
        }

        [HttpGet]
        public ActionResult Delete(string isbn)
        {
            var findBook = this.service.FindByTag(isbn);

            return this.View(findBook);
        }

        [HttpPost]
        public ActionResult Delete(string isbn, FormCollection collection)
        {
            try
            {
                this.service.Remove(isbn);

                return this.RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Error = "This book is not kept!";
                return this.View();
            }
        }
    }
}