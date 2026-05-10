using System;
using System.ComponentModel.DataAnnotations;

namespace FoodHeaven.Models
{
    public class ShipperLog
    {
        [Key]
        public int id { get; set; }
        public string message { get; set; } = string.Empty;
        public DateTime LogTime { get; set; } = DateTime.Now;
    }
}
