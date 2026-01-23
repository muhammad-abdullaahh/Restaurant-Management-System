using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodHeaven.Models
{
    public class DailyStat
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int TotalOrders { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalRevenue { get; set; }

        public int TotalReservations { get; set; }
    }
}
