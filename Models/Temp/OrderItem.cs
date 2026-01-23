using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodHeaven.Models.Temp;

[Index("MenuItemId", Name = "IX_OrderItems_MenuItemId")]
[Index("OrderId", Name = "IX_OrderItems_OrderId")]
public partial class OrderItem
{
    [Key]
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int MenuItemId { get; set; }

    public int Quantity { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    public string? Customization { get; set; }

    [ForeignKey("MenuItemId")]
    [InverseProperty("OrderItems")]
    public virtual MenuItem MenuItem { get; set; } = null!;

    [ForeignKey("OrderId")]
    [InverseProperty("OrderItems")]
    public virtual Order Order { get; set; } = null!;
}
