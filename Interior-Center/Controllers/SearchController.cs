using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Interior_Center.Models;
using Interior_Center.Data;

namespace Interior_Center.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Внедрение ApplicationDbContext через конструктор
        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Index(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                ViewBag.Message = "Введите хотя бы одну букву.";
                return View();
            }

            // Поиск по базе данных
            var results = _context.Catalog
                .Where(p => p.Name.ToLower().StartsWith(query.ToLower()))
                .ToList();

            return View(results);
        }
        // GET: SearchController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SearchController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SearchController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SearchController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SearchController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SearchController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SearchController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SearchController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
