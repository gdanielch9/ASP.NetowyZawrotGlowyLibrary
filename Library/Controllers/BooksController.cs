using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library.Models;
using Microsoft.AspNet.Identity;

namespace Library.Content
{
    public class BooksController : Controller
    {


        private ApplicationDbContext db = new ApplicationDbContext(); 

        // GET: Books
        public ActionResult Index(string searchQuery = null, int? searchGenreId = null)
        {

            IEnumerable<Book> bookList;
            ViewBag.Genre = ToSelectList(db.Genres.ToList());

            if (String.IsNullOrEmpty(searchQuery))
                bookList = db.Books.ToList();
            else
                bookList = db.Books.Where(x => x.Title.ToLower().Contains(searchQuery.ToLower())).ToList();

            if (searchGenreId != null)
                bookList = db.Books.Where(x => x.GenreId == searchGenreId).ToList();

            if (Request.IsAjaxRequest())
                return PartialView("_BookList",bookList); 

            return View(bookList);
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.Genre = ToSelectList(db.Genres.ToList());
            return PartialView("_Create");
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return PartialView("_BookList", db.Books.ToList()); 
            }
            else
                return Content("SHIIIIT");
        }

        public ActionResult BookSuggestions(string term)
        {
            var bookList = db.Books.Where(x => x.Title.ToLower().Contains(term.ToLower())).ToList();
            return Json(bookList, JsonRequestBehavior.AllowGet);
      }

        public static List<SelectListItem> ToSelectList(List<Genre> genre)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (Genre g in genre)
            {
                items.Add(new SelectListItem()
                {
                    Text = g.Name,
                    Value = g.Id.ToString()
                });
            }
            return items;
        }

        // GET: Books/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Book book = db.Books.Find(id);
        //    if (book == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(book);
        //}

        // POST: Books/Delete/5
        [/*HttpPost,*/ ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Ksiazka/Borrow/5
        [Authorize]
        public ActionResult Borrow(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            book.IsBorrowed = true;
            book.UserId = User.Identity.GetUserId();
            db.SaveChanges();        // seve changes in found record 

            return RedirectToAction("Index");
        }

        // GET: Ksiazka/Return/5
        [Authorize]
        public ActionResult Return(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            book.IsBorrowed = false;
            db.SaveChanges();        // seve changes in found record 

            return RedirectToAction("Index");
        }

        // GET: Ksiazka/Status/5
        public ActionResult Status(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            if (book.IsBorrowed == true)
                TempData["Message"] = "This book is borrowed";
            else
                TempData["Message"] = "This book is available";

            return View();
        }

        [Authorize]
        public ActionResult MyBooks()
        {
            return View(db.Books.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public string TellMeDate()
        {
            return DateTime.Now.ToString();
        }
    }

}
