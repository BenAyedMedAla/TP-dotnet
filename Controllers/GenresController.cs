using Microsoft.AspNetCore.Mvc;

namespace WebApplicationINSAT.Controllers
{
    public class GenresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
