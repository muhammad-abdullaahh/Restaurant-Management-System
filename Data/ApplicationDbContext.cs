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
                    ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuDNrvAofLcEQx3a1ZXD2766HUT65ZwhGPi1k1AXhl64HEavGi8nxRyffeK2LQ1oxPd2l434Oa94YXAZT12CMqKjQTBF2Jb-8E5dAceM7FJUcelHF-6c4q15awtGEgO3PLu8mQM5UI5IuBTsZxo8YpUNEtR4k4Z2U6u_W2XctSp_0D7ecrWJK422mSw0xZv6oUUGBnX3XTr0Y3po6FEJ-BVMbMMnqK4FYYNU0u4RQkSQXKzN3eFrWYD2bhYIjwKQERuzO1vUb6O07Q",
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
                    ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuDfWitYE4hwDczx9Z-VIscp8kFY3t1c7tJueP_sW0XkR6EW2YM0vC1M4_LrFzbnykXuUg7lmcsy1nz-rL4x03gJfzB9iXMzCFJtTORYym8uJDHJbCoEygHqUJcYT59qBjkpnS3np4Zwu_KX8k8v1wrgeaTcao1EbDmNjz-ij4cjZFHcM-yo-cJIeTFaj2BOvoxkNCp5lu566DDOVAcqyZHIolGrMV4W-f9hRXH5a9eBfPjt2axi-Nvk3uFpAfFKy36vLmF4e1HOPQ",
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
                    ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuB6wcyAKmNM9_xGQUed-hjbJioT5oPF1lfh6_YbyCXMg1W1ZmaCd888UKjOvluITeTAyZPMtsQLFPWIjDmcTA5L7-RIWceRR39xPbsEcpOodl0BlxDfLK7a83dW2hL-Qx5i1NIThF5cd7UWbJ-VPAHuHxYYpDg4vf7OvTOKGaOFEve1TWfFYLyjCXLKVbvORWtJXkb9sNMimTocvC86q0GPyCW192ZYAIMFQGCWGruiREfd_yXW2Sd6Szt5uHjg3W8cNgX14E-L_A",
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
                    ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuAOWTa96d3PDsIuBSmkXVzVmNNqgO6qTsZbDREDQrB5WGTILshF9ZltdJbzZgh2JmYs1b04ng6cxGTfbFaI6Ov9Sri1Kj1a5dbbTs-az4YbGwjlttdjz8EwCI7kfNvUrLK0lG7Sa8ZA_38oTTK34NMlzahtTxf8D1IJC5nDJTxZ36ZoDhEiiZJJ0JNaI0FaLiI_2YGLWW27ocmtwBl9atsG6F9G4toUYoKJWYWsPljAHz2nAT4qcw7o4AF4UVQeXiKuN2p4bh79zQ",
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

            // Seed default admin user (username: admin, password: Admin@123)

        }
    }
}
