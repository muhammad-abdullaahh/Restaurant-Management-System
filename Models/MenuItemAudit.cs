using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodHeaven.Models
{
    [Table("MenuItemAudit")]
    public class MenuItemAudit
    {
        [Key]
        public int AuditID { get; set; }
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; } = string.Empty;
        public string ActionType { get; set; } = string.Empty; // 'SOFT_DELETE'
        public DateTime ChangedAt { get; set; } = DateTime.Now;
    }
}
