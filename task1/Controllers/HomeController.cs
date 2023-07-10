using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using System.IO;
using System.Linq;
using task1.Models;

namespace task1.Controllers
{
    public class HomeController : Controller
    {
       task1Context db=new task1Context();
        public IActionResult Index()
        {
            ViewBag.Book = db.Books.ToList();
            ViewBag.Category = db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(string BookName,float BookPrice, int CategoryId, IFormFile Photo)
        {
            Book b = new Book();
            ViewBag.Category = db.Categories.ToList();
            string fName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + Path.GetExtension(Photo.FileName);
            using (Stream st = new FileStream("wwwroot/img/" + fName, FileMode.Create))
            {
                Photo.CopyTo(st);
            }
            b.BookName = BookName;
            b.BookPrice = BookPrice;
            b.Photo = fName;
            b.CategoryId = CategoryId;
            db.Books.Add(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BookDelete(int id)
        {
            Book b = db.Books.Find(id);
            db.Books.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BookView()
        {
            ViewBag.Book.Photo = db.Books.ToList();
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult UpdateBook(int id, Book b, IFormFile Photo)
        {
            Book bb = db.Books.Find(id);
            bb.BookName = b.BookName;
            bb.BookPrice = b.BookPrice;
            string fName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + Path.GetExtension(Photo.FileName);
            using (Stream st = new FileStream("wwwroot/img/" + fName, FileMode.Create))
            {
                Photo.CopyTo(st);
            }
            bb.Photo = fName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
