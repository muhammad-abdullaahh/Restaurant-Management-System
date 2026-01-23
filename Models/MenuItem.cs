using System.ComponentModel.DataAnnotations;

namespace FoodHeaven.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Item name is required")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0.01, 10000.00)]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; } = string.Empty; // Starters, Mains, Desserts, Drinks, Healthy

        public string? ImageUrl { get; set; }

        [Range(0, 5)]
        public double Rating { get; set; }

        public int ReviewCount { get; set; }

        public bool IsAvailable { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public DateTime? UpdatedAt { get; set; }
    }
}
