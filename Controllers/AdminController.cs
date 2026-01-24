using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using FoodHeaven.Data;
using FoodHeaven.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FoodHeaven.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
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

            if (admin != null && BCrypt.Net.BCrypt.Verify(password, admin.PasswordHash))
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
            
            // Stats
            // Stats
            ViewBag.TotalOrders = await _context.Orders.CountAsync();
            
            // Fix for SQLite: Client-side aggregation
            var orderTotals = await _context.Orders
                .Where(o => o.Status == "Completed" || o.Status == "Delivered")
                .Select(o => (decimal?)o.Total)
                .ToListAsync();
            var orderRevenue = orderTotals.Sum() ?? 0;

            var reservationCosts = await _context.Reservations
                .Where(r => r.Status == "Completed")
                .Select(r => (decimal?)r.EstimatedCost)
                .ToListAsync();
            var premiumRevenue = reservationCosts.Sum() ?? 0;

            ViewBag.TotalRevenue = orderRevenue + premiumRevenue;
            ViewBag.PremiumRevenue = premiumRevenue;
            
            ViewBag.TotalReservations = await _context.Reservations.CountAsync();

            ViewBag.PendingOrders = await _context.Orders
                .CountAsync(o => o.Status == "Pending");

            ViewBag.UnreadMessages = await _context.ContactMessages
                .CountAsync(m => !m.IsRead);

            ViewBag.TotalReservations = await _context.Reservations.CountAsync();
            ViewBag.TodaysReservations = await _context.Reservations.CountAsync(r => r.ReservationDate.Date == today);

            // Get recent orders
            var recentOrders = await _context.Orders
                .OrderByDescending(o => o.OrderDate)
                .Take(5)
                .ToListAsync();

            ViewBag.RecentOrders = recentOrders;

            // Get recent messages
            var recentMessages = await _context.ContactMessages
                .OrderByDescending(m => m.CreatedAt)
                .Take(5)
                .ToListAsync();

            ViewBag.RecentMessages = recentMessages;

            // Get recent users
            var recentUsers = await _context.Users
                .OrderByDescending(u => u.LastLoginAt ?? u.CreatedAt)
                .Take(5)
                .ToListAsync();

            ViewBag.RecentUsers = recentUsers;
            
            // Stats
            ViewBag.TotalUsers = await _context.Users.CountAsync();
            ViewBag.TotalAdmins = await _context.Admins.CountAsync();

            // Return menu items for the main view content if needed, or null if view handles it differently
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
        public async Task<JsonResult> GetOrdersData()
        {
            var orders = await _context.Orders
                .OrderByDescending(o => o.OrderDate)
                .Take(100)
                .Select(o => new {
                    o.Id,
                    CustomerName = o.CustomerName ?? "Guest",
                    o.DeliveryAddress,
                    o.Total,
                    o.Status,
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
                    Password = a.PlainPassword // Use the new PlainPassword field
                })
                .ToListAsync();
            return Json(admins);
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

                admin.PasswordHash = BCrypt.Net.BCrypt.HashPassword(admin.PlainPassword);
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
        public async Task<JsonResult> GetReservationsData()
        {
            var reservations = await _context.Reservations
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
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return Json(new { success = false, message = "Order not found" });

            order.Status = status;
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<JsonResult> UpdateReservationStatus(int id, string status)
        {
            var res = await _context.Reservations.FindAsync(id);
            if (res == null) return Json(new { success = false, message = "Reservation not found" });

            res.Status = status;
            await _context.SaveChangesAsync();
            return Json(new { success = true });
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
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(defaultPass);

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
    }
}
