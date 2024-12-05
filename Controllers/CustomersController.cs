using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationINSAT.Models;

namespace WebApplicationINSAT.Controllers
{
    public class CustomersController : Controller
    {
        public readonly ApplicationDbcontext _db;
        public CustomersController(ApplicationDbcontext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var customerDetails = _db.Customers.Join(_db.Membershiptypes,
              customer => customer.MembershipId, // Foreign key from Customers
              membership => membership.Id,      // Primary key from Membershiptypes
              (customer, membership) => new
              {
                  CustomerName = customer.Name,
                  cusid = customer.Id,
                  Dicrate = membership.DiscountRate
              }).ToList();
            ViewBag.CustomerDetails = customerDetails;
            return View();
        }
        // GET: Movie/Create
        public IActionResult Create()
        {
            var members = _db.Membershiptypes.ToList();
            ViewBag.Member = members.Select(members => new SelectListItem()
            {
                Text = members.Name,
                Value = members.Id.ToString()
            }).ToList();
            return View();
        }
        // POST: Movie/Create
        [HttpPost]
        public IActionResult Create(Customers c)
        {
            if (!ModelState.IsValid)
            {
                // Collect errors to display in the view
                ViewBag.Errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                var members = _db.Membershiptypes.ToList();
                ViewBag.member = members.Select(members => new SelectListItem()
                {
                    Text = members.Name,
                    Value = members.Id.ToString()

                }).ToList();
                return View();
            }
                 c.Id = new Guid();
                _db.Customers.Add(c);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(Guid id) { 
        var custo = _db.Customers.FirstOrDefault(m => m.Id == id);
     if (custo == null)
     {
         return NotFound();
    }
     return View(custo);
}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Customers c)
        {
            if (c == null)
            {
                return NotFound();
            }

            _db.Customers.Remove(c); // Remove the movie from the database
            _db.SaveChanges(); // Save changes to the database
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(Guid id)
        {
            var customer = _db.Customers
                               .Include(c => c.Membership)
                      .Include(c => c.Moviesc)
                      .FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        public IActionResult Edit(Guid id)
        {
            var custo = _db.Customers.FirstOrDefault(m => m.Id == id);
            if (custo == null)
            {
                return NotFound();
            }
            var members = _db.Membershiptypes.ToList();
            ViewBag.Member = members.Select(m => new SelectListItem()
            {
                Text = m.Name,
                Value = m.Id.ToString(),
                Selected = (m.Id == custo.MembershipId) // Mark selected if it matches the customer's membership
            }).ToList();
            return View(custo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customers c)
        {
         
            _db.Customers.Update(c); 
            _db.SaveChanges(); // Save changes to the database
            return RedirectToAction(nameof(Index));
        }

    }
}
