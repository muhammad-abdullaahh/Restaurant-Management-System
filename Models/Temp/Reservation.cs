using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodHeaven.Models.Temp;

public partial class Reservation
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string CustomerName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? Email { get; set; }

    public DateTime ReservationDate { get; set; }

    public TimeOnly ReservationTime { get; set; }

    public int PartySize { get; set; }

    public string TableNumber { get; set; } = null!;

    public string? SpecialRequests { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string ReservationType { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal EstimatedCost { get; set; }

    public bool IsPremiumTable { get; set; }
}
