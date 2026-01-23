using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodHeaven.Models.Temp;

[Index("LoyaltyAccountId", Name = "IX_LoyaltyTransactions_LoyaltyAccountId")]
public partial class LoyaltyTransaction
{
    [Key]
    public int Id { get; set; }

    public int LoyaltyAccountId { get; set; }

    public string TransactionType { get; set; } = null!;

    public int Points { get; set; }

    public string? Description { get; set; }

    public int? OrderId { get; set; }

    public DateTime TransactionDate { get; set; }

    [ForeignKey("LoyaltyAccountId")]
    [InverseProperty("LoyaltyTransactions")]
    public virtual LoyaltyAccount LoyaltyAccount { get; set; } = null!;
}
