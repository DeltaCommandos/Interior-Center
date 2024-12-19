using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Interior_Center.Data;
using Interior_Center.Models;
using System.Linq;
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
        public IActionResult AddToCart([FromBody] int id)
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (email == null)
            {
                return Json(new { success = false, message = "Пользователь не авторизован." });
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return Json(new { success = false, message = "Пользователь не найден." });
            }

            user.Cart.Add(id);
            _context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
