using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodHeaven.Models.Temp;

public partial class MenuItem
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(500)]
    public string Description { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    public string Category { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public double Rating { get; set; }

    public int ReviewCount { get; set; }

    public bool IsAvailable { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("MenuItem")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
