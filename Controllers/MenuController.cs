using Microsoft.AspNetCore.Mvc;
using FoodHeaven.Data;
using FoodHeaven.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;

namespace FoodHeaven.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;

        public MenuController(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        // GET: Menu
        public async Task<IActionResult> Index(string? category, string? search)
        {
            const string cacheKey = "FullMenuList";
            
            // 1. Fetch/Seed All Real Items from DB (with caching)
            if (!_cache.TryGetValue(cacheKey, out List<MenuItem> allItems))
            {
                allItems = await _context.MenuItems.Where(m => m.IsAvailable).ToListAsync();

                // 2. Seed if empty
                if (!allItems.Any())
                {
                    var categoriesData = MenuData.GetCategoriesData();
                    var newItems = new List<MenuItem>();
                    int idCounter = 10000;

                    foreach (var categoryPair in categoriesData)
                    {
                        var cat = categoryPair.Key;
                        var names = categoryPair.Value.Names;
                        var images = categoryPair.Value.Images;
                        var prices = categoryPair.Value.Prices;
                        var descriptions = categoryPair.Value.Descriptions;

                        for (int i = 0; i < names.Length; i++)
                        {
                            newItems.Add(new MenuItem {
                                Id = idCounter++,
                                Name = names[i],
                                Description = i < descriptions.Length ? descriptions[i] : $"Signature {names[i]}",
                                Price = prices[i],
                                Category = cat,
                                ImageUrl = images[i],
                                Rating = 4.0 + (i % 10) / 10.0,
                                IsAvailable = true,
                                CreatedAt = DateTime.Now
                            });
                        }
                    }

                    if (newItems.Any())
                    {
                        var strategy = _context.Database.CreateExecutionStrategy();
                        await strategy.ExecuteAsync(async () => {
                            using var transaction = await _context.Database.BeginTransactionAsync();
                            try 
                            {
                                if (_context.Database.IsSqlServer())
                                    await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT MenuItems ON");
                                
                                await _context.MenuItems.AddRangeAsync(newItems);
                                await _context.SaveChangesAsync();
                                
                                if (_context.Database.IsSqlServer())
                                    await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT MenuItems OFF");
                                
                                await transaction.CommitAsync();
                            }
                            catch 
                            {
                                await transaction.RollbackAsync();
                                throw;
                            }
                        });
                        allItems = newItems;
                    }
                }

                var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(1));
                _cache.Set(cacheKey, allItems, cacheOptions);
            }

            // 3. Update Categories Viewbag
            ViewBag.Categories = allItems.Select(m => m.Category).Distinct().OrderBy(c => c).ToList();

            // 4. Filtering logic (on the list in memory for speed)
            var filteredItems = allItems;

            if (!string.IsNullOrEmpty(category) && category != "All" && category != "Deals")
            {
                filteredItems = filteredItems.Where(m => m.Category == category).ToList();
            }

            if (!string.IsNullOrEmpty(search))
            {
                filteredItems = filteredItems.Where(m => 
                    m.Name.Contains(search, StringComparison.OrdinalIgnoreCase) || 
                    (m.Description != null && m.Description.Contains(search, StringComparison.OrdinalIgnoreCase))
                ).ToList();
                ViewBag.SearchQuery = search;
                ViewBag.SelectedCategory = "Search Results";
            } 
            else 
            {
                ViewBag.SelectedCategory = category ?? "All";
            }

            ViewBag.Deals = await _context.Deals.Where(d => d.IsActive).ToListAsync();

            return View(filteredItems.OrderBy(m => m.Category).ThenBy(m => m.Name).ToList());
        }


        // GET: Menu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItem = await _context.MenuItems
                .FirstOrDefaultAsync(m => m.Id == id);

            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }

        // API endpoint to get menu items (for AJAX calls)
        [HttpGet]
        public async Task<JsonResult> GetMenuItems(string? category, string? search)
        {
            var menuItems = _context.MenuItems.AsQueryable();

            if (!string.IsNullOrEmpty(category) && category != "All")
            {
                menuItems = menuItems.Where(m => m.Category == category);
            }

            if (!string.IsNullOrEmpty(search))
            {
                menuItems = menuItems.Where(m => m.Name.Contains(search) || (m.Description != null && m.Description.Contains(search)));
            }

            var items = await menuItems
                .OrderBy(m => m.Category)
                .ThenBy(m => m.Name)
                .ToListAsync();

            return Json(items);
        }

        // API endpoint to get a single menu item (for Admin Edit)
        [HttpGet]
        public async Task<JsonResult> GetMenuItem(int id)
        {
            var item = await _context.MenuItems.FindAsync(id);
            if (item == null) return Json(new { success = false, message = "Item not found" });
            return Json(new { success = true, item });
        }

        // =================================================================
        // ADMIN MANAGEMENT ACTIONS
        // =================================================================

        // POST: Menu/Create (Admin)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                // Ensure ID doesn't conflict (autogen or manual)
                menuItem.CreatedAt = DateTime.Now;
                _context.MenuItems.Add(menuItem);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Item created successfully" });
            }
            return Json(new { success = false, message = "Invalid data" });
        }

        // POST: Menu/Edit/5 (Admin)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [FromBody] MenuItem menuItem)
        {
            if (id != menuItem.Id)
            {
                return Json(new { success = false, message = "ID mismatch" });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuItem);
                    await _context.SaveChangesAsync();
                    return Json(new { success = true, message = "Item updated successfully" });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.MenuItems.Any(e => e.Id == id))
                    {
                        return Json(new { success = false, message = "Item not found" });
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Json(new { success = false, message = "Invalid data" });
        }

        // POST: Menu/Delete/5 (Admin)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem != null)
            {
                _context.MenuItems.Remove(menuItem);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Item deleted successfully" });
            }
            return Json(new { success = false, message = "Item not found" });
        }
    }
}
