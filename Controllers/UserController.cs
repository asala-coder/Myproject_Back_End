using MyProject.Models;
using Microsoft.AspNetCore.Mvc;
using MyProject.Data;

namespace MyProject.Controllers
{
    public class UserController : Controller
    {
        private readonly MyProject.Data.ApplicationDbContext _context;
        public UserController(ApplicationDbContext Context)
        {
            _context = Context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var existing = _context.users.FirstOrDefault(mazen => mazen.Email == user.Email);
            if (existing != null)
            {
                if (existing.Email == user.Email && existing.Password == user.Password)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "Password OR Email are incorrect";
                    return View(user);
                }
            }
            else
            {
                ViewBag.error = "user dose not exist";
                return View(user);
            }

        }
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            _context.users.Add(user);
            _context.SaveChanges();
            return View("Login");
        }
    }
}
