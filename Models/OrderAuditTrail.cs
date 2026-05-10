using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodHeaven.Models
{
    [Table("OrderAuditTrail")]
    public class OrderAuditTrail
    {
        [Key]
        public int AuditID { get; set; }
        public int OrderID { get; set; }
        public string ActionType { get; set; } = string.Empty;
        public DateTime ActionTime { get; set; } = DateTime.Now;
    }
}
