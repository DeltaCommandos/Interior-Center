using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Interior_Center.Data;
using Interior_Center.Models;
using System.Text.Json;

namespace Interior_Center.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddToCart([FromBody] string itemId)
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(userEmail))
            {
                return Json(new { success = false, message = "Вы не авторизованы!" });
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);
            if (user == null)
            {
                return Json(new { success = false, message = "Пользователь не найден!" });
            }

            user.Cart ??= new List<string>(); // Инициализация корзины, если null
            user.Cart.Add(itemId);
            _context.SaveChanges();

            return Json(new { success = true });
        }

        public IActionResult GetCart()
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(userEmail))
            {
                return Json(new { success = false, message = "Вы не авторизованы!" });
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);
            if (user == null || user.Cart == null)
            {
                return Json(new { success = true, items = new List<string>() });
            }

            var items = _context.Catalog.Where(c => user.Cart.Contains(c.ID.ToString())).ToList();
            return Json(new { success = true, items });
        }

        [HttpPost]
        public IActionResult RemoveFromCart([FromBody] string itemId)
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");
            var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);

            if (user?.Cart == null || !user.Cart.Contains(itemId))
            {
                return Json(new { success = false, message = "Корзина пуста или товар не найден!" });
            }

            user.Cart.Remove(itemId);
            _context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
