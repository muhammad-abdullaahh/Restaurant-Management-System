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
                // Validate that all menu items exist
                var menuItemIds = order.OrderItems.Select(oi => oi.MenuItemId).Distinct().ToList();
                var existingMenuItems = await _context.MenuItems
                    .Where(m => menuItemIds.Contains(m.Id))
                    .Select(m => m.Id)
                    .ToListAsync();

                var invalidIds = menuItemIds.Except(existingMenuItems).ToList();
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
                 // Debug: Show what claims we have
                 ViewBag.DebugMessage = "No User ID found. Claims: " + string.Join(", ", User.Claims.Select(c => $"{c.Type}={c.Value}"));
                 return View(new List<Order>());
             }

             var orders = await _context.Orders
                 .Include(o => o.OrderItems)
                 .ThenInclude(oi => oi.MenuItem)
                 .Where(o => o.UserId == userId)
                 .OrderByDescending(o => o.OrderDate)
                 .ToListAsync();

             // Debug info
             ViewBag.UserId = userId;
             ViewBag.Username = User.Identity.Name;
             ViewBag.OrderCount = orders.Count;

             return View(orders);
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
