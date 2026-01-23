using System.ComponentModel.DataAnnotations;

namespace FoodHeaven.Models
{
    public class LoyaltyAccount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CustomerId { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        [Required]
        public int Points { get; set; } = 0;

        [Required]
        public string MembershipTier { get; set; } = "Bronze"; // Bronze, Silver, Gold, Platinum

        public int LunchPunchCount { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? LastActivityDate { get; set; }

        // Navigation property
        public ICollection<LoyaltyTransaction> Transactions { get; set; } = new List<LoyaltyTransaction>();
    }

    public class LoyaltyTransaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int LoyaltyAccountId { get; set; }

        [Required]
        public string TransactionType { get; set; } = string.Empty; // Earn, Redeem, Expire

        [Required]
        public int Points { get; set; }

        public string? Description { get; set; }

        public int? OrderId { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.Now;

        // Navigation property
        public LoyaltyAccount LoyaltyAccount { get; set; } = null!;
    }
}
