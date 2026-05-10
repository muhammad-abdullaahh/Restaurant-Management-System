using Microsoft.EntityFrameworkCore;
using FoodHeaven.Models;

namespace FoodHeaven.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<LoyaltyAccount> LoyaltyAccounts { get; set; }
        public DbSet<LoyaltyTransaction> LoyaltyTransactions { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DailyStat> DailyStats { get; set; }
        public DbSet<Deal> Deals { get; set; }
        
        // Database Triggers Logs
        public DbSet<ReservationAudit> ReservationAudits { get; set; }
        public DbSet<OrderAuditTrail> OrderAuditTrails { get; set; }
        public DbSet<MenuItemAudit> MenuItemAudits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure decimal precision
            modelBuilder.Entity<DailyStat>()
                .Property(ds => ds.TotalRevenue)
                .HasPrecision(18, 2);

            modelBuilder.Entity<MenuItem>()
                .Property(m => m.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.Subtotal)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.DeliveryFee)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.Tax)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.Total)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.Discount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.Price)
                .HasPrecision(10, 2);

            // Configure Triggers to prevent EF Core OUTPUT clause errors
            modelBuilder.Entity<Reservation>()
                .ToTable(tb => tb.HasTrigger("trg_Reservation_Audit"));
            
            modelBuilder.Entity<MenuItem>()
                .ToTable(tb => tb.HasTrigger("trg_MenuItem_SoftDelete"));
            
            modelBuilder.Entity<Order>()
                .ToTable(tb => tb.HasTrigger("trg_Orders_AutoStats"));

            // Seed initial data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Menu Items
            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem
                {
                    Id = 1,
                    Name = "Truffle Risotto",
                    Description = "Creamy arborio rice with fresh black truffles and parmesan crisp.",
                    Price = 24.00m,
                    Category = "Mains",
                    ImageUrl = "/images/truffle_risotto.png",
                    Rating = 4.9,
                    ReviewCount = 128,
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 2,
                    Name = "Pan-Seared Salmon",
                    Description = "Atlantic salmon with lemon butter sauce and grilled asparagus.",
                    Price = 28.00m,
                    Category = "Mains",
                    ImageUrl = "/images/platter_seafood.jpg",
                    Rating = 4.7,
                    ReviewCount = 85,
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 3,
                    Name = "Royal Wagyu Burger",
                    Description = "Premium wagyu beef patty, aged cheddar, truffle mayo on brioche.",
                    Price = 22.00m,
                    Category = "Mains",
                    ImageUrl = "/images/wagyu_burger.png",
                    Rating = 4.8,
                    ReviewCount = 210,
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 4,
                    Name = "Golden Truffle Burger",
                    Description = "Wagyu beef with truffle oil",
                    Price = 18.50m,
                    Category = "Mains",
                    ImageUrl = "/images/truffle_burger.png",
                    Rating = 4.8,
                    ReviewCount = 95,
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 5,
                    Name = "Spicy Thai Basil Pasta",
                    Description = "Fresh basil, chili, garlic",
                    Price = 14.00m,
                    Category = "Mains",
                    ImageUrl = "/images/platter_italian.jpg",
                    Rating = 4.5,
                    ReviewCount = 67,
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 6,
                    Name = "Creamy Avocado Toast",
                    Description = "Sourdough, lemon, chili flakes",
                    Price = 12.00m,
                    Category = "Starters",
                    ImageUrl = "/images/avocado_toast.png",
                    Rating = 4.9,
                    ReviewCount = 143,
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 7,
                    Name = "Berry Smoothie",
                    Description = "Blueberry, banana, chia seeds",
                    Price = 9.50m,
                    Category = "Drinks",
                    ImageUrl = "/images/berry_smoothie.jpg",
                    Rating = 4.7,
                    ReviewCount = 88,
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 8,
                    Name = "Buddha Bowl",
                    Description = "Quinoa, chickpeas, tahini",
                    Price = 11.00m,
                    Category = "Healthy",
                    ImageUrl = "/images/platter_health.jpg",
                    Rating = 4.6,
                    ReviewCount = 72,
                    IsAvailable = true
                },
                new MenuItem
                {
                    Id = 9,
                    Name = "Fluffy Pancakes",
                    Description = "Maple syrup, fresh berries",
                    Price = 13.50m,
                    Category = "Desserts",
                    ImageUrl = "/images/fluffy_pancakes.png",
                    Rating = 5.0,
                    ReviewCount = 156,
                    IsAvailable = true
                }
            );

            // Seed Deals
            modelBuilder.Entity<Deal>().HasData(
                new Deal
                {
                    Id = 1,
                    Title = "Family Feast Bundle",
                    Description = "2 Royal Wagyu Burgers, 2 Spicy Thai Basil Pastas, and 4 Berry Smoothies.",
                    Price = 59.99m,
                    OriginalPrice = 82.00m,
                    ImageUrl = "/images/deals/family_feast.jpg",
                    Tag = "Family Choice",
                    IsActive = true
                },
                new Deal
                {
                    Id = 2,
                    Title = "Date Night Special",
                    Description = "2 Truffle Risottos, 1 bottle of sparkling juice, and Fluffy Pancakes for two.",
                    Price = 45.00m,
                    OriginalPrice = 61.50m,
                    ImageUrl = "/images/deals/date_night.jpg",
                    Tag = "Popular",
                    IsActive = true
                },
                new Deal
                {
                    Id = 3,
                    Title = "Healthy Morning Kick",
                    Description = "Creamy Avocado Toast paired with a giant Berry Smoothie.",
                    Price = 18.00m,
                    OriginalPrice = 21.50m,
                    ImageUrl = "/images/deals/healthy_morning.jpg",
                    Tag = "Chef Special",
                    IsActive = true
                },
                new Deal
                {
                    Id = 4,
                    Title = "BBQ Lovers Platter",
                    Description = "Mixed grill selection, 4 pieces of Seekh Kabab, 4 Tikka pieces, and 2 Garlic Naans.",
                    Price = 34.99m,
                    OriginalPrice = 45.00m,
                    ImageUrl = "/images/deals/bbq_lovers.jpg",
                    Tag = "Hot Seller",
                    IsActive = true
                },
                new Deal
                {
                    Id = 5,
                    Title = "Seafood Extravaganza",
                    Description = "Grilled Salmon, Golden Calamari, and Prawn Cocktail with a side of herb butter rice.",
                    Price = 49.99m,
                    OriginalPrice = 65.00m,
                    ImageUrl = "/images/deals/seafood_extravaganza.jpg",
                    Tag = "Premium",
                    IsActive = true
                },
                new Deal
                {
                    Id = 6,
                    Title = "Weekend Brunch for Two",
                    Description = "2 Continental Breakfast platters, 2 Iced Coffees, and 1 Dessert sampler.",
                    Price = 39.99m,
                    OriginalPrice = 52.00m,
                    ImageUrl = "/images/deals/weekend_brunch.jpg",
                    Tag = "Weekend Only",
                    IsActive = true
                },
                new Deal
                {
                    Id = 7,
                    Title = "Pasta Party Bundle",
                    Description = "Choose any 3 Pasta dishes and get a large Garlic Bread Supreme for free.",
                    Price = 42.00m,
                    OriginalPrice = 55.00m,
                    ImageUrl = "/images/deals/pasta_party.jpg",
                    Tag = "Value Deal",
                    IsActive = true
                },
                new Deal
                {
                    Id = 8,
                    Title = "Burger Madness",
                    Description = "3 Classic Cheeseburgers, 3 Masala Fries, and 3 Coca Cola drinks.",
                    Price = 29.99m,
                    OriginalPrice = 38.00m,
                    ImageUrl = "/images/deals/burger_madness.jpg",
                    Tag = "Fast & Tasty",
                    IsActive = true
                },
                new Deal
                {
                    Id = 9,
                    Title = "Sweet Tooth Combo",
                    Description = "Molten Lava Cake, Triple Chocolate Cake, and 2 Vanilla Bean Ice Cream scoops.",
                    Price = 22.00m,
                    OriginalPrice = 28.50m,
                    ImageUrl = "/images/deals/sweet_tooth.jpg",
                    Tag = "Dessert King",
                    IsActive = true
                },
                new Deal
                {
                    Id = 10,
                    Title = "Desi Royal Feast",
                    Description = "Chicken Biryani (Full), Mutton Karahi (Half), 4 Roti/Naan, and a bottle of Coke (1.5L).",
                    Price = 54.99m,
                    OriginalPrice = 68.00m,
                    ImageUrl = "/images/deals/desi_royal_feast.jpg",
                    Tag = "Desi Special",
                    IsActive = true
                },
                new Deal
                {
                    Id = 11,
                    Title = "Pizza Party Pack",
                    Description = "2 Large Pizzas of your choice, 1 portion of Chicken Wings (10pcs), and 1 large Salad bowl.",
                    Price = 44.99m,
                    OriginalPrice = 58.50m,
                    ImageUrl = "/images/deals/pizza_party.jpg",
                    Tag = "Party Time",
                    IsActive = true
                }
            );


        }
    }
}
