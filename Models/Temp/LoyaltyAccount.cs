using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodHeaven.Models.Temp;

public partial class LoyaltyAccount
{
    [Key]
    public int Id { get; set; }

    public string CustomerId { get; set; } = null!;

    [StringLength(100)]
    public string CustomerName { get; set; } = null!;

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public int Points { get; set; }

    public string MembershipTier { get; set; } = null!;

    public int LunchPunchCount { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? LastActivityDate { get; set; }

    [InverseProperty("LoyaltyAccount")]
    public virtual ICollection<LoyaltyTransaction> LoyaltyTransactions { get; set; } = new List<LoyaltyTransaction>();
}
