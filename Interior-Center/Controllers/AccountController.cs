using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Interior_Center.Data;
using Interior_Center.Models;
using System.Linq;

namespace Interior_Center.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Register(string email, string password, string surname, string name, string fathername, int phoneNumber)
        {
            if (_context.Users.Any(u => u.Email == email))
            {
                ViewBag.Message = "Пользователь с таким email уже существует.";
                return RedirectToAction("Index", "Home");
            }

            var user = new Users
            {
                Email = email,
                Password = password,
                Surname = surname,
                Name = name,
                Fathername = fathername,
                PhoneNumber = phoneNumber,
                Cart = new List<int>() // Инициализируем пустым списком
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            HttpContext.Session.SetString("UserEmail", email);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("UserEmail", email);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Неверный email или пароль.";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserEmail");
            return RedirectToAction("Index", "Home");
        }

        
    }
}
