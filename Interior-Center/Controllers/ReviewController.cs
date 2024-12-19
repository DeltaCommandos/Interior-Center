using Interior_Center.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Interior_Center.Models;


namespace Interior_Center.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReviewController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Reviews()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Reviews(string email, string name, string description)
        {

            var review = new Reviews
            {
                Email = email,
                Name = name,
                Description = description,
            };

            _context.Reviews.Add(review);
            _context.SaveChanges();

            HttpContext.Session.SetString("UserEmail", email);
            return RedirectToAction("Index", "Home");
        }
    }
}
