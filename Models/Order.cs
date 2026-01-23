using System.ComponentModel.DataAnnotations;

namespace FoodHeaven.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string OrderNumber { get; set; } = string.Empty;

        public string? CustomerName { get; set; }

        public string? CustomerEmail { get; set; }

        public string? CustomerPhone { get; set; }

        [Required]
        public decimal Subtotal { get; set; }

        [Required]
        public decimal DeliveryFee { get; set; }

        [Required]
        public decimal Tax { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        public string Status { get; set; } = "Pending"; // Pending, Preparing, Ready, Delivered, Cancelled

        public string? PromoCode { get; set; }

        public decimal Discount { get; set; }

        public string? SpecialInstructions { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public DateTime? CompletedDate { get; set; }

        public string? DeliveryAddress { get; set; } // New field

        public string? PaymentMethod { get; set; } // New field

        public int? UserId { get; set; }
        public User? User { get; set; }

        // Navigation property
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }

    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int MenuItemId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string? Customization { get; set; }

        // Navigation properties
        public Order Order { get; set; } = null!;
        public MenuItem MenuItem { get; set; } = null!;
    }
}
