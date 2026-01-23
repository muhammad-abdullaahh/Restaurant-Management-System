using Microsoft.AspNetCore.Mvc;
using FoodHeaven.Data;
using FoodHeaven.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodHeaven.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var featuredItems = await _context.MenuItems
                .Where(m => m.IsAvailable)
                .OrderByDescending(m => m.Rating)
                .Take(5)
                .ToListAsync();

            ViewBag.FeaturedItems = featuredItems;
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe([FromBody] string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return Json(new { success = false, message = "Email address is required." });
            }

            if (!new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(email))
            {
                 return Json(new { success = false, message = "Please enter a valid email address." });
            }

            // Check if already subscribed
            var exists = await _context.Subscribers.AnyAsync(s => s.Email == email);
            if (exists)
            {
                return Json(new { success = false, message = "You are already subscribed!" });
            }

            _context.Subscribers.Add(new Subscriber { Email = email });
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Welcome to the FoodHeaven Family!" });
        }
    }
}
