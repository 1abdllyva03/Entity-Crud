using Microsoft.AspNetCore.Mvc;
using System.Linq;
using task1.Models;

namespace task1.Controllers
{
    public class User : Controller
    {
        task1Context db = new task1Context();

        public object UserName { get; internal set; }
        public object UserPassword { get; internal set; }

        public IActionResult Index()
        {
            ViewBag.Category=db.Categories.ToList();
            ViewBag.Book = db.Books.ToList();
            return View();
        }
        public IActionResult CategoryIndex()
        {
            ViewBag.Category=db.Categories.ToList();
            ViewBag.Book = db.Books.ToList();
            return View();
        }
    }
}
