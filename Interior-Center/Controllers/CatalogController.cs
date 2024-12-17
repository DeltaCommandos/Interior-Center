using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Interior_Center.Data;
using Interior_Center.Models;

namespace Interior_Center.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Получение всех товаров из базы данных
            var catalogItems = _context.Catalog.ToList();
            return View(catalogItems);
        }

        // Фильтрация по типу "Спальня"
        public IActionResult Bedroom()
        {
            var bedroomItems = _context.Catalog
                .Where(item => item.Type == "Спальня")
                .ToList();
            return View("Index", bedroomItems); // Использует то же представление
        }
        public IActionResult Kitchen()
        {
            var KitchenItems = _context.Catalog
                .Where(item => item.Type == "Кухня")
                .ToList();
            return View("Index", KitchenItems); // Использует то же представление
        }
        public IActionResult Childroom()
        {
            var ChildroomItems = _context.Catalog
                .Where(item => item.Type == "Детская")
                .ToList();
            return View("Index", ChildroomItems); // Использует то же представление
        }
        public IActionResult Livingroom()
        {
            var LivingItems = _context.Catalog
                .Where(item => item.Type == "Гостинная")
                .ToList();
            return View("Index", LivingItems); // Использует то же представление
        }
        public IActionResult Corridor()
        {
            var CorridorItems = _context.Catalog
                .Where(item => item.Type == "Прихожая")
                .ToList();
            return View("Index", CorridorItems); // Использует то же представление
        }
        public IActionResult Mirror()
        {
            var MirrorItems = _context.Catalog
                .Where(item => item.Type == "Полка")
                .ToList();
            return View("Index", MirrorItems); // Использует то же представление
        }
    }
}
