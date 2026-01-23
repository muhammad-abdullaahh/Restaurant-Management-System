using System.ComponentModel.DataAnnotations;

namespace FoodHeaven.Models
{
    public class Subscriber
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime SubscribedAt { get; set; } = DateTime.Now;
    }
}
