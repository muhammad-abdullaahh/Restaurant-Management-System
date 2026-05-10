using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FoodHeaven.Data;
using FoodHeaven.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodHeaven.Controllers
{
    public class LoyaltyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoyaltyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Loyalty/Index
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var customerId = $"USER-{userId}";
            var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
            var name = User.Identity?.Name ?? "Valued Customer";

            var loyaltyAccount = await _context.LoyaltyAccounts
                .Include(l => l.Transactions)
                .FirstOrDefaultAsync(l => l.CustomerId == customerId);

            if (loyaltyAccount == null)
            {
                // Create a new account for the real user
                loyaltyAccount = new LoyaltyAccount
                {
                    CustomerId = customerId,
                    CustomerName = name,
                    Email = email,
                    Points = 0,
                    MembershipTier = "Bronze",
                    LunchPunchCount = 0,
                    CreatedAt = DateTime.Now,
                    LastActivityDate = DateTime.Now
                };

                _context.LoyaltyAccounts.Add(loyaltyAccount);
                await _context.SaveChangesAsync();
            }

            return View(loyaltyAccount);
        }

        // POST: Loyalty/RedeemReward
        [HttpPost]
        public async Task<JsonResult> RedeemReward(string customerId, int points, string rewardName)
        {
            try
            {
                var account = await _context.LoyaltyAccounts
                    .FirstOrDefaultAsync(l => l.CustomerId == customerId);

                if (account == null)
                {
                    return Json(new { success = false, message = "Account not found" });
                }

                if (account.Points < points)
                {
                    return Json(new { success = false, message = "Insufficient points" });
                }

                // Deduct points
                account.Points -= points;
                account.LastActivityDate = DateTime.Now;

                // Add transaction record
                var transaction = new LoyaltyTransaction
                {
                    LoyaltyAccountId = account.Id,
                    TransactionType = "Redeem",
                    Points = -points,
                    Description = $"Redeemed: {rewardName}",
                    TransactionDate = DateTime.Now
                };

                _context.LoyaltyTransactions.Add(transaction);
                await _context.SaveChangesAsync();

                return Json(new { success = true, remainingPoints = account.Points, message = $"Successfully redeemed {rewardName}!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // POST: Loyalty/AddPoints
        [HttpPost]
        public async Task<JsonResult> AddPoints(string customerId, int points, int? orderId)
        {
            try
            {
                var account = await _context.LoyaltyAccounts
                    .FirstOrDefaultAsync(l => l.CustomerId == customerId);

                if (account == null)
                {
                    return Json(new { success = false, message = "Account not found" });
                }

                account.Points += points;
                account.LastActivityDate = DateTime.Now;

                // Update membership tier based on points
                if (account.Points >= 2000)
                    account.MembershipTier = "Platinum";
                else if (account.Points >= 1000)
                    account.MembershipTier = "Gold";
                else if (account.Points >= 500)
                    account.MembershipTier = "Silver";
                else
                    account.MembershipTier = "Bronze";

                // Add transaction record
                var transaction = new LoyaltyTransaction
                {
                    LoyaltyAccountId = account.Id,
                    TransactionType = "Earn",
                    Points = points,
                    Description = orderId.HasValue ? $"Points earned from Order #{orderId}" : "Points earned",
                    OrderId = orderId,
                    TransactionDate = DateTime.Now
                };

                _context.LoyaltyTransactions.Add(transaction);
                await _context.SaveChangesAsync();

                return Json(new { success = true, totalPoints = account.Points, tier = account.MembershipTier });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // GET: Loyalty/GetHistory
        [HttpGet]
        public async Task<JsonResult> GetHistory(string customerId, int take = 20)
        {
            var account = await _context.LoyaltyAccounts
                .Include(l => l.Transactions.OrderByDescending(t => t.TransactionDate).Take(take))
                .FirstOrDefaultAsync(l => l.CustomerId == customerId);

            if (account == null)
            {
                return Json(new { success = false, message = "Account not found" });
            }

            return Json(new { success = true, transactions = account.Transactions });
        }
    }
}
