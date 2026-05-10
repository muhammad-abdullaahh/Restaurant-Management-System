using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FoodHeaven.Data;
using FoodHeaven.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodHeaven.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Order/Cart
        public IActionResult Cart()
        {
            return View();
        }

        // GET: Order/Checkout
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Create([FromBody] Order order)
        {
            try
            {
                // Check if restaurant is open
                var now = DateTime.Now;
                var day = now.DayOfWeek;
                var hour = now.Hour;
                bool isOpen = false;

                if (hour >= 9) {
                    isOpen = true; // Opens at 9 AM every day
                } else {
                    // Check if we are in the late night shift of the previous day
                    var prevDay = day == DayOfWeek.Sunday ? DayOfWeek.Saturday : day - 1;
                    if (prevDay == DayOfWeek.Saturday || prevDay == DayOfWeek.Sunday) {
                        if (hour < 4) isOpen = true; // Weekend stays open until 4 AM
                    } else {
                        if (hour < 3) isOpen = true; // Weekday stays open until 3 AM
                    }
                }
                
                if (!isOpen)
                {
                    string hoursMsg = (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday) 
                        ? "9:00 AM to 4:00 AM" 
                        : "9:00 AM to 3:00 AM";
                    return Json(new { success = false, message = $"Sorry, the restaurant is currently closed. Today's hours are {hoursMsg}." });
                }

                // Validate that all menu items exist (Check both MenuItems and Deals)
                var menuItemIds = order.OrderItems.Select(oi => oi.MenuItemId).Distinct().ToList();
                
                var existingMenuItems = await _context.MenuItems
                    .Where(m => menuItemIds.Contains(m.Id))
                    .Select(m => m.Id)
                    .ToListAsync();

                var existingDeals = await _context.Deals
                    .Where(d => menuItemIds.Contains(d.Id))
                    .Select(d => d.Id)
                    .ToListAsync();

                var allValidIds = existingMenuItems.Concat(existingDeals).Distinct().ToList();

                var invalidIds = menuItemIds.Except(allValidIds).ToList();
                if (invalidIds.Any())
                {
                    return Json(new { 
                        success = false, 
                        message = $"Invalid menu items: {string.Join(", ", invalidIds)}. Please refresh the page and try again." 
                    });
                }

                // Generate order number
                order.OrderNumber = $"ORD-{DateTime.Now:yyyyMMdd}-{new Random().Next(1000, 9999)}";
                order.OrderDate = DateTime.Now;
                order.Status = "Pending";

                // Link User
                if (User.Identity?.IsAuthenticated == true)
                {
                    var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
                    if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
                    {
                        order.UserId = userId;
                    }

                    // Auto-fill from User Claims if missing
                    if (string.IsNullOrEmpty(order.CustomerName))
                    {
                        order.CustomerName = User.Identity.Name;
                    }
                    if (string.IsNullOrEmpty(order.CustomerEmail))
                    {
                         order.CustomerEmail = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
                    }
                }

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                // Loyalty Points Integration
                if (order.UserId.HasValue)
                {
                    try
                    {
                        var customerId = $"USER-{order.UserId}";
                        var loyaltyAccount = await _context.LoyaltyAccounts.FirstOrDefaultAsync(l => l.CustomerId == customerId);
                        
                        if (loyaltyAccount == null)
                        {
                            loyaltyAccount = new LoyaltyAccount
                            {
                                CustomerId = customerId,
                                CustomerName = order.CustomerName ?? "Valued Customer",
                                Email = order.CustomerEmail,
                                Points = 0,
                                MembershipTier = "Bronze",
                                CreatedAt = DateTime.Now
                            };
                            _context.LoyaltyAccounts.Add(loyaltyAccount);
                            await _context.SaveChangesAsync();
                        }

                        // Calculate points: 10 points per $1
                        int earnedPoints = (int)(order.Total * 10);
                        loyaltyAccount.Points += earnedPoints;
                        loyaltyAccount.LastActivityDate = DateTime.Now;

                        // Update tier
                        if (loyaltyAccount.Points >= 2000) loyaltyAccount.MembershipTier = "Platinum";
                        else if (loyaltyAccount.Points >= 1000) loyaltyAccount.MembershipTier = "Gold";
                        else if (loyaltyAccount.Points >= 500) loyaltyAccount.MembershipTier = "Silver";

                        var transaction = new LoyaltyTransaction
                        {
                            LoyaltyAccountId = loyaltyAccount.Id,
                            TransactionType = "Earn",
                            Points = earnedPoints,
                            Description = $"Points earned from Order #{order.OrderNumber}",
                            OrderId = order.Id,
                            TransactionDate = DateTime.Now
                        };
                        _context.LoyaltyTransactions.Add(transaction);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        // Log loyalty error but don't fail the order
                        Console.WriteLine($"Loyalty Error: {ex.Message}");
                    }
                }

                return Json(new { success = true, orderNumber = order.OrderNumber, orderId = order.Id });
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (ex.InnerException != null)
                {
                    message += " | Inner: " + ex.InnerException.Message;
                }
                return Json(new { success = false, message = message });
            }
        }

        // GET: Order/MyOrders
        public async Task<IActionResult> MyOrders()
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
             if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
             {
                 return RedirectToAction("Login", "Account");
             }

             var orders = await _context.Orders
                 .Include(o => o.OrderItems)
                 .ThenInclude(oi => oi.MenuItem)
                 .Where(o => o.UserId == userId && o.Status != "Delivered" && o.Status != "Completed")
                 .OrderByDescending(o => o.OrderDate)
                 .ToListAsync();

             var reservations = await _context.Reservations
                 .Where(r => r.UserId == userId)
                 .OrderByDescending(r => r.ReservationDate)
                 .ToListAsync();

             var viewModel = new UserActivityViewModel
             {
                 Orders = orders,
                 Reservations = reservations,
                 UserId = userId,
                 Username = User.Identity?.Name ?? "User"
             };

             return View(viewModel);
        }

        // POST: Order/Cancel
        [HttpPost]
        public async Task<JsonResult> Cancel(int id)
        {
            try
            {
                var order = await _context.Orders
                    .Include(o => o.OrderItems)
                    .FirstOrDefaultAsync(o => o.Id == id);

                if (order == null)
                {
                    return Json(new { success = false, message = "Order not found" });
                }

                // Only allow cancelling if Pending
                if (order.Status != "Pending")
                {
                    return Json(new { success = false, message = $"Cannot cancel order with status: {order.Status}" });
                }

                // Remove associated Loyalty Transactions if any
                var transactions = await _context.LoyaltyTransactions.Where(t => t.OrderId == id).ToListAsync();
                if (transactions.Any())
                {
                    _context.LoyaltyTransactions.RemoveRange(transactions);
                }

                // Remove OrderItems and then the Order itself
                _context.OrderItems.RemoveRange(order.OrderItems);
                _context.Orders.Remove(order);
                
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Order removed successfully from database" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // GET: Order/Confirmation/{id}
        public async Task<IActionResult> Confirmation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Order/UpdateStatus
        [HttpPost]
        public async Task<JsonResult> UpdateStatus(int orderId, string status)
        {
            try
            {
                var order = await _context.Orders.FindAsync(orderId);
                if (order == null)
                {
                    return Json(new { success = false, message = "Order not found" });
                }

                order.Status = status;
                if (status == "Delivered" || status == "Completed")
                {
                    order.CompletedDate = DateTime.Now;
                }

                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // GET: Order/ApplyPromoCode
        [HttpGet]
        public JsonResult ApplyPromoCode(string promoCode, decimal subtotal)
        {
            // Simple promo code logic - you can expand this
            var discount = 0m;
            var validCodes = new Dictionary<string, decimal>
            {
                { "SAVE10", 0.10m },
                { "SAVE20", 0.20m },
                { "FIRST15", 0.15m }
            };

            if (validCodes.ContainsKey(promoCode.ToUpper()))
            {
                discount = subtotal * validCodes[promoCode.ToUpper()];
                return Json(new { success = true, discount = discount, message = "Promo code applied!" });
            }

            return Json(new { success = false, message = "Invalid promo code" });
        }
    }
}
