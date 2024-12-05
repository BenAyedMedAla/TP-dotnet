using Microsoft.AspNetCore.Mvc;
using WebApplicationINSAT.Models;

namespace WebApplicationINSAT.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbcontext _db;
        public MoviesController(ApplicationDbcontext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movies m)
        {
            if (ModelState.IsValid)
            {
                _db.Movies.Add(m);
                _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(m);
        }

    }
}
