using Microsoft.AspNetCore.Mvc;
using FoodHeaven.Data;
using FoodHeaven.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace FoodHeaven.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;

        public HomeController(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<IActionResult> Index()
        {
            const string cacheKey = "FeaturedItems";

            if (!_cache.TryGetValue(cacheKey, out List<MenuItem> featuredItems))
            {
                featuredItems = await _context.MenuItems
                    .Where(m => m.IsAvailable)
                    .OrderByDescending(m => m.Rating)
                    .Take(5)
                    .ToListAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(2));
                _cache.Set(cacheKey, featuredItems, cacheOptions);
            }

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
