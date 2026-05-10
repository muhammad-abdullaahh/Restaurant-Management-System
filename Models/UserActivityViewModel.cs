using System.Collections.Generic;

namespace FoodHeaven.Models
{
    public class UserActivityViewModel
    {
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
    }
}
