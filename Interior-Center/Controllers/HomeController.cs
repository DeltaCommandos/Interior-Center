using Interior_Center.Data;
using Interior_Center.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using System.Diagnostics;

namespace Interior_Center.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ApplicationDbContext _context;
        //public HomeController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }
        public IActionResult Delivery()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[HttpGet]
        //public IActionResult Search(string query)
        //{
        //    // Проверка на пустой запрос
        //    if (string.IsNullOrWhiteSpace(query))
        //    {
        //        return View("~/Views/Home/search.cshtml", Enumerable.Empty<Catalog>());
        //    }

        //    // Поиск по товарам
        //    var results = _context.Catalog
        //        .Where(g => g.Name.Contains(query) || g.Short.Contains(query) || g.Long.Contains(query))
        //        .ToList();

        //    return View("~/Views/Home/search.cshtml", results);
        //}
    }
}
