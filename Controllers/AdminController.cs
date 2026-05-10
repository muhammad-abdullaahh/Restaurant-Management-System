using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using FoodHeaven.Data;
using FoodHeaven.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.Extensions.Caching.Memory;

namespace FoodHeaven.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;

        public AdminController(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        // GET: Admin/Login
        public IActionResult Login()
        {
            if (User.Identity?.IsAuthenticated == true && User.IsInRole("Admin"))
            {
                return RedirectToAction(nameof(Dashboard));
            }
            return View();
        }

        // POST: Admin/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            var admin = await _context.Admins
                .FirstOrDefaultAsync(a => a.Username == username && a.IsActive);

            if (admin != null && password == admin.PlainPassword)
            {
                // Update last login
                admin.LastLoginAt = DateTime.Now;
                await _context.SaveChangesAsync();

                // Create claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, admin.Username),
                    new Claim(ClaimTypes.Email, admin.Email),
                    new Claim("FullName", admin.FullName),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8)
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction(nameof(Dashboard));
            }

            TempData["ErrorMessage"] = "Invalid username or password";
            return View();
        }

        // GET: Admin/Logout
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

                // GET: Admin/Dashboard
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Dashboard()
        {
            var today = DateTime.Today;
            const string cacheKey = "AdminDashboardStats";

            if (!_cache.TryGetValue(cacheKey, out dynamic stats))
            {
                var orderRevenue = await _context.Orders
                    .Where(o => o.Status == "Completed" || o.Status == "Delivered")
                    .SumAsync(o => (decimal?)o.Total) ?? 0;

                var premiumRevenue = await _context.Reservations
                    .Where(r => r.Status == "Completed")
                    .SumAsync(r => (decimal?)r.EstimatedCost) ?? 0;

                stats = new
                {
                    TotalOrders = await _context.Orders.CountAsync(),
                    TotalRevenue = orderRevenue + premiumRevenue,
                    PremiumRevenue = premiumRevenue,
                    TotalReservations = await _context.Reservations.CountAsync(),
                    PendingOrders = await _context.Orders.CountAsync(o => o.Status == "Pending"),
                    UnreadMessages = await _context.ContactMessages.CountAsync(m => !m.IsRead),
                    TodaysReservations = await _context.Reservations.CountAsync(r => r.ReservationDate.Date == today),
                    TotalUsers = await _context.Users.CountAsync(),
                    TotalAdmins = await _context.Admins.CountAsync()
                };

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(30));

                _cache.Set(cacheKey, (object)stats, cacheEntryOptions);
            }

            ViewBag.TotalOrders = stats.TotalOrders;
            ViewBag.TotalRevenue = stats.TotalRevenue;
            ViewBag.PremiumRevenue = stats.PremiumRevenue;
            ViewBag.TotalReservations = stats.TotalReservations;
            ViewBag.PendingOrders = stats.PendingOrders;
            ViewBag.UnreadMessages = stats.UnreadMessages;
            ViewBag.TodaysReservations = stats.TodaysReservations;
            ViewBag.TotalUsers = stats.TotalUsers;
            ViewBag.TotalAdmins = stats.TotalAdmins;

            // Recent activities (Always fresh)
            ViewBag.RecentOrders = await _context.Orders
                .OrderByDescending(o => o.OrderDate)
                .Take(5)
                .ToListAsync();

            ViewBag.RecentMessages = await _context.ContactMessages
                .OrderByDescending(m => m.CreatedAt)
                .Take(5)
                .ToListAsync();

            ViewBag.RecentUsers = await _context.Users
                .OrderByDescending(u => u.LastLoginAt ?? u.CreatedAt)
                .Take(5)
                .ToListAsync();

            return View();
        }

        // GET: Admin/Reservations
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Reservations()
        {
            var reservations = await _context.Reservations
                .OrderByDescending(r => r.ReservationDate)
                .ThenBy(r => r.ReservationTime)
                .ToListAsync();

            return View(reservations);
        }

        // ===================================
        // AJAX API ENDPOINTS FOR DASHBOARD
        // ===================================

        [HttpGet]
        public async Task<JsonResult> GetOrdersData(string? search)
        {
            var query = _context.Orders.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(o => (o.CustomerName != null && o.CustomerName.Contains(search)) || o.Id.ToString() == search);
            }

            var orders = await query
                .OrderByDescending(o => o.OrderDate)
                .Take(100)
                .Select(o => new {
                    o.Id,
                    CustomerName = o.CustomerName ?? "Guest",
                    o.DeliveryAddress,
                    o.Total,
                    o.Status,
                    o.PromoCode,
                    o.Discount,
                    Date = o.OrderDate.ToString("g")
                })
                .ToListAsync();
            return Json(orders);
        }

        [HttpGet]
        public async Task<JsonResult> GetAdminsData()
        {
            var admins = await _context.Admins
                .OrderByDescending(a => a.CreatedAt)
                .Select(a => new {
                    a.Id,
                    a.FullName,
                    a.Email,
                    Role = "Admin",
                    Joined = a.CreatedAt.ToShortDateString(),
                    LastLogin = a.LastLoginAt.HasValue ? a.LastLoginAt.Value.ToString("g") : "Never",
                    Password = a.PlainPassword,
                    a.IsActive
                })
                .ToListAsync();
            return Json(admins);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> ToggleAdminStatus(int id, bool isActive)
        {
            var admin = await _context.Admins.FindAsync(id);
            if (admin == null) return Json(new { success = false, message = "Admin not found" });

            admin.IsActive = isActive;
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> AddAdmin([FromBody] Admin admin)
        {
            try
            {
                // Validate if username/email exists
                if (await _context.Admins.AnyAsync(a => a.Username == admin.Username || a.Email == admin.Email))
                {
                    return Json(new { success = false, message = "Username or Email already exists" });
                }

                // Temporary plain password logic - for real apps, validate complexity
                if (string.IsNullOrEmpty(admin.PlainPassword))
                {
                    return Json(new { success = false, message = "Password is required" });
                }


                admin.CreatedAt = DateTime.Now;
                admin.IsActive = true;
                
                // If FullName is missing, default it
                if(string.IsNullOrEmpty(admin.FullName)) admin.FullName = admin.Username;

                _context.Admins.Add(admin);
                await _context.SaveChangesAsync();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetReservationsData(string? search)
        {
            var query = _context.Reservations.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(r => r.CustomerName.Contains(search));
            }

            var reservations = await query
                .OrderByDescending(r => r.ReservationDate)
                .ThenBy(r => r.ReservationTime)
                .Take(100)
                .Select(r => new {
                    r.Id,
                    r.CustomerName,
                    Date = r.ReservationDate.ToShortDateString(),
                    Time = DateTime.Today.Add(r.ReservationTime).ToString("hh:mm tt"),
                    r.PartySize,
                    r.Status,
                    r.ReservationType
                })
                .ToListAsync();
            return Json(reservations);
        }

        [HttpGet]
        public async Task<JsonResult> GetUsersData()
        {
            var users = await _context.Users
                .OrderByDescending(u => u.CreatedAt)
                .Select(u => new {
                    u.Id,
                    FullName = u.Username, // Mapping Username to FullName for JS compatibility
                    u.Email,
                    u.Password, // Return the plain password
                    Joined = u.CreatedAt.ToShortDateString(),
                    LastLogin = u.LastLoginAt.HasValue ? u.LastLoginAt.Value.ToString("g") : "Never"
                })
                .ToListAsync();
            return Json(users);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateOrderStatus(int id, string status)
        {
            try
            {
                var order = await _context.Orders.FindAsync(id);
                if (order == null) return Json(new { success = false, message = "Order not found" });

                order.Status = status;
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.InnerException?.Message ?? ex.Message });
            }
        }

        [HttpPost]
        public async Task<JsonResult> UpdateReservationStatus(int id, string status)
        {
            try
            {
                var res = await _context.Reservations.FindAsync(id);
                if (res == null) return Json(new { success = false, message = "Reservation not found" });

                res.Status = status;
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.InnerException?.Message ?? ex.Message });
            }
        }

        [HttpPost]
        public async Task<JsonResult> ResetUserPassword(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null) return Json(new { success = false, message = "User not found" });

                string defaultPass = "123456";
                user.Password = defaultPass;

                await _context.SaveChangesAsync();
                return Json(new { success = true, newPassword = defaultPass });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<JsonResult> ClearAllOrders()
        {
            try 
            {
                var orders = await _context.Orders.ToListAsync();
                var orderItems = await _context.OrderItems.ToListAsync();
                
                // --- SAVE DAILY STATS ---
                var today = DateTime.Today; // 00:00:00
                // Find any report created TODAY (ignoring time component match)
                var stat = await _context.DailyStats
                    .FirstOrDefaultAsync(d => d.Date >= today && d.Date < today.AddDays(1));

                if (stat == null)
                {
                    stat = new DailyStat 
                    { 
                        Date = DateTime.Now,
                        TotalOrders = orders.Count,
                        TotalRevenue = orders.Where(o => o.Status != "Cancelled").Sum(o => o.Total)
                    };
                    _context.DailyStats.Add(stat);
                }
                else 
                {
                    // Merge into existing today's report
                    stat.Date = DateTime.Now; // Update timestamp
                    stat.TotalOrders += orders.Count;
                    stat.TotalRevenue += orders.Where(o => o.Status != "Cancelled").Sum(o => o.Total);
                }
                // ------------------------

                _context.OrderItems.RemoveRange(orderItems);
                _context.Orders.RemoveRange(orders);
                
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<JsonResult> ClearAllReservations()
        {
            try
            {
                var reservations = await _context.Reservations.ToListAsync();
                
                // --- SAVE DAILY STATS ---
                var today = DateTime.Today;
                var stat = await _context.DailyStats
                    .FirstOrDefaultAsync(d => d.Date >= today && d.Date < today.AddDays(1));

                if (stat == null)
                {
                    stat = new DailyStat 
                    { 
                        Date = DateTime.Now,
                        TotalReservations = reservations.Count,
                        TotalRevenue = reservations.Where(r => r.Status != "Cancelled").Sum(r => r.EstimatedCost)
                    };
                    _context.DailyStats.Add(stat);
                }
                else
                {
                    // Merge
                    stat.Date = DateTime.Now;
                    stat.TotalReservations += reservations.Count;
                    stat.TotalRevenue += reservations.Where(r => r.Status != "Cancelled").Sum(r => r.EstimatedCost);
                }
                // ------------------------

                _context.Reservations.RemoveRange(reservations);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<JsonResult> ClearAllHistory()
        {
            try
            {
                var stats = await _context.DailyStats.ToListAsync();
                _context.DailyStats.RemoveRange(stats);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetHistoryData()
        {
            var stats = await _context.DailyStats
                .OrderByDescending(d => d.Date)
                .Select(s => new {
                    s.Id,
                    Date = s.Date.ToString("g"), // Changed to General Date/Time format
                    s.TotalOrders,
                    s.TotalRevenue,
                    s.TotalReservations
                })
                .ToListAsync();
            return Json(stats);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<JsonResult> GetMenuItems(string? category, string? search)
        {
            if (category == "Deals")
            {
                var dealQuery = _context.Deals.AsQueryable();
                if (!string.IsNullOrEmpty(search))
                {
                    dealQuery = dealQuery.Where(d => d.Title.Contains(search) || d.Description.Contains(search));
                }

                var deals = await dealQuery
                    .OrderByDescending(d => d.CreatedAt)
                    .Select(d => new {
                        d.Id,
                        Name = d.Title,
                        Category = "Deals",
                        d.Price,
                        d.ImageUrl,
                        IsAvailable = d.IsActive,
                        d.Description
                    })
                    .ToListAsync();
                return Json(deals);
            }

            var query = _context.MenuItems.AsQueryable();

            if (!string.IsNullOrEmpty(category) && category != "All")
            {
                query = query.Where(m => m.Category == category);
            }

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(m => m.Name.Contains(search) || m.Description.Contains(search));
            }

            var items = await query
                .OrderBy(m => m.Category)
                .ThenBy(m => m.Name)
                .Select(m => new {
                    m.Id,
                    m.Name,
                    m.Category,
                    m.Price,
                    m.ImageUrl,
                    m.IsAvailable,
                    m.Description
                })
                .ToListAsync();

            return Json(items);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<JsonResult> GetMenuItem(int id)
        {
            var item = await _context.MenuItems.FindAsync(id);
            if (item == null) return Json(new { success = false, message = "Item not found" });
            return Json(new { success = true, item });
        }

        // POST: Admin/AddMenuItem
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<JsonResult> AddMenuItem([FromBody] MenuItem menuItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    menuItem.CreatedAt = DateTime.Now;
                    menuItem.IsAvailable = true;

                    _context.MenuItems.Add(menuItem);
                    await _context.SaveChangesAsync();

                    return Json(new { success = true, item = menuItem });
                }

                return Json(new { success = false, message = "Invalid data" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // POST: Admin/UpdateMenuItem
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<JsonResult> UpdateMenuItem([FromBody] MenuItem menuItem)
        {
            try
            {
                var existingItem = await _context.MenuItems.FindAsync(menuItem.Id);
                if (existingItem == null)
                {
                    return Json(new { success = false, message = "Menu item not found" });
                }

                existingItem.Name = menuItem.Name;
                existingItem.Description = menuItem.Description;
                existingItem.Price = menuItem.Price;
                existingItem.Category = menuItem.Category;
                existingItem.ImageUrl = menuItem.ImageUrl;
                existingItem.Rating = menuItem.Rating;
                existingItem.ReviewCount = menuItem.ReviewCount;
                existingItem.IsAvailable = menuItem.IsAvailable;
                existingItem.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();
                return Json(new { success = true, item = existingItem });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // POST: Admin/ToggleMenuItemAvailability
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<JsonResult> ToggleMenuItemAvailability(int id, bool isAvailable)
        {
            try
            {
                var existingItem = await _context.MenuItems.FindAsync(id);
                if (existingItem == null)
                {
                    return Json(new { success = false, message = "Menu item not found" });
                }

                existingItem.IsAvailable = isAvailable;
                existingItem.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // POST: Admin/DeleteMenuItem
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<JsonResult> DeleteMenuItem(int id)
        {
            try
            {
                var menuItem = await _context.MenuItems.FindAsync(id);
                if (menuItem == null)
                {
                    return Json(new { success = false, message = "Menu item not found" });
                }

                _context.MenuItems.Remove(menuItem);
                await _context.SaveChangesAsync();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // GET: Admin/GetOrders
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<JsonResult> GetOrders(string? status)
        {
            var orders = _context.Orders.Include(o => o.OrderItems).AsQueryable();

            if (!string.IsNullOrEmpty(status))
            {
                orders = orders.Where(o => o.Status == status);
            }

            var orderList = await orders
                .OrderByDescending(o => o.OrderDate)
                .Take(50)
                .ToListAsync();

            return Json(orderList);
        }

        // GET: Admin/GetMessages
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<JsonResult> GetMessages(bool? unreadOnly)
        {
            var messages = _context.ContactMessages.AsQueryable();

            if (unreadOnly == true)
            {
                messages = messages.Where(m => !m.IsRead);
            }

            var messageList = await messages
                .OrderByDescending(m => m.CreatedAt)
                .Take(50)
                .ToListAsync();

            return Json(messageList);
        }

        // POST: Admin/MarkMessageRead
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<JsonResult> MarkMessageRead(int id)
        {
            try
            {
                var message = await _context.ContactMessages.FindAsync(id);
                if (message == null)
                {
                    return Json(new { success = false, message = "Message not found" });
                }

                message.IsRead = true;
                await _context.SaveChangesAsync();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // POST: Admin/CleanReservation
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<JsonResult> CleanReservation(int id)
        {
            try
            {
                var reservation = await _context.Reservations.FindAsync(id);
                if (reservation == null)
                {
                    return Json(new { success = false, message = "Reservation not found" });
                }

                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> ClearAllMessages()
        {
            try
            {
                var messages = await _context.ContactMessages.ToListAsync();
                _context.ContactMessages.RemoveRange(messages);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // --- SUBSCRIBERS ---
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetSubscribers()
        {
            var subscribersData = await _context.Subscribers
                .OrderByDescending(s => s.SubscribedAt)
                .ToListAsync();

            var subscribers = subscribersData.Select(s => new {
                s.Id,
                s.Email,
                Date = s.SubscribedAt.ToString("g")
            });

            return Json(subscribers);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> DeleteSubscriber(int id)
        {
            try
            {
                var subscriber = await _context.Subscribers.FindAsync(id);
                if (subscriber == null) return Json(new { success = false, message = "Subscriber not found" });

                _context.Subscribers.Remove(subscriber);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // --- DEALS (CHEF SPECIALS) ---
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetDealsData(string? search)
        {
            var query = _context.Deals.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(d => d.Title.Contains(search) || d.Description.Contains(search) || d.Tag.Contains(search));
            }

            var deals = await query
                .OrderByDescending(d => d.CreatedAt)
                .Select(d => new {
                    d.Id,
                    d.Title,
                    d.Price,
                    d.OriginalPrice,
                    d.Tag,
                    d.ImageUrl,
                    d.IsActive,
                    d.Description
                })
                .ToListAsync();

            return Json(deals);
        }

        // --- DATABASE LOGS (TRIGGERS) ---
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetDatabaseLogsData()
        {
            try
            {
                var reservationAudits = await _context.ReservationAudits
                    .OrderByDescending(a => a.ChangedAt)
                    .Take(50)
                    .Select(r => new {
                        customerName = r.CustomerName,
                        actionType = r.ActionType,
                        oldStatus = r.OldStatus,
                        newStatus = r.NewStatus,
                        changedAt = r.ChangedAt
                    })
                    .ToListAsync();

                var menuItemAudits = await _context.MenuItemAudits
                    .OrderByDescending(a => a.ChangedAt)
                    .Take(50)
                    .Select(m => new {
                        menuItemName = m.MenuItemName,
                        actionType = m.ActionType,
                        changedAt = m.ChangedAt
                    })
                    .ToListAsync();

                return Json(new { success = true, reservationAudits, menuItemAudits });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<JsonResult> TestSoftDeleteTrigger(int itemId)
        {
            try
            {
                // This will fire the INSTEAD OF DELETE trigger on MenuItems
                await _context.Database.ExecuteSqlRawAsync($"DELETE FROM MenuItems WHERE Id = {itemId}");
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> AddDeal([FromBody] Deal deal)
        {
            try
            {
                if (deal == null) return Json(new { success = false, message = "Invalid data" });
                deal.CreatedAt = DateTime.Now;
                _context.Deals.Add(deal);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> UpdateDeal([FromBody] Deal deal)
        {
            try
            {
                var existing = await _context.Deals.FindAsync(deal.Id);
                if (existing == null) return Json(new { success = false, message = "Deal not found" });

                existing.Title = deal.Title;
                existing.Description = deal.Description;
                existing.Price = deal.Price;
                existing.OriginalPrice = deal.OriginalPrice;
                existing.ImageUrl = deal.ImageUrl;
                existing.Tag = deal.Tag;
                existing.IsActive = deal.IsActive;

                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> DeleteDeal(int id)
        {
            try
            {
                var deal = await _context.Deals.FindAsync(id);
                if (deal == null) return Json(new { success = false, message = "Deal not found" });

                _context.Deals.Remove(deal);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> ToggleDealStatus(int id, bool isActive)
        {
            try
            {
                var deal = await _context.Deals.FindAsync(id);
                if (deal == null) return Json(new { success = false, message = "Deal not found" });

                deal.IsActive = isActive;
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}

