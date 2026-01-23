using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodHeaven.Models.Temp;

[Index("UserId", Name = "IX_Orders_UserId")]
public partial class Order
{
    [Key]
    public int Id { get; set; }

    public string OrderNumber { get; set; } = null!;

    public string? CustomerName { get; set; }

    public string? CustomerEmail { get; set; }

    public string? CustomerPhone { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Subtotal { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal DeliveryFee { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Tax { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Total { get; set; }

    public string Status { get; set; } = null!;

    public string? PromoCode { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Discount { get; set; }

    public string? SpecialInstructions { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime? CompletedDate { get; set; }

    public string? DeliveryAddress { get; set; }

    public string? PaymentMethod { get; set; }

    public int? UserId { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [ForeignKey("UserId")]
    [InverseProperty("Orders")]
    public virtual User? User { get; set; }
}
