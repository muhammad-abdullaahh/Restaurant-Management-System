using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodHeaven.Models
{
    [Table("ReservationAudit")]
    public class ReservationAudit
    {
        [Key]
        public int AuditID { get; set; }
        public int ReservationId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string ActionType { get; set; } = string.Empty;
        public string OldStatus { get; set; } = string.Empty;
        public string NewStatus { get; set; } = string.Empty;
        public DateTime ChangedAt { get; set; } = DateTime.Now;
    }
}
