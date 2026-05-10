using System.ComponentModel.DataAnnotations;

namespace FoodHeaven.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        [Required]
        public TimeSpan ReservationTime { get; set; }

        [Required]
        [Range(1, 20)]
        public int PartySize { get; set; }

        [Required]
        public string TableNumber { get; set; } = string.Empty;

        public string ReservationType { get; set; } = "Standard"; // Standard, PrivateParty

        public string? SpecialRequests { get; set; }

        [Required]
        public string Status { get; set; } = "Confirmed"; // Confirmed, Cancelled, Completed

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }
        
        public bool IsPremiumTable { get; set; } = false;
        
        public decimal EstimatedCost { get; set; } = 0;
        
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
