using System;
using System.Collections.Generic;
using FoodHeaven.Models.Temp;
using Microsoft.EntityFrameworkCore;

namespace FoodHeaven.Data;

public partial class FoodHeavenDbContext : DbContext
{
    public FoodHeavenDbContext()
    {
    }

    public FoodHeavenDbContext(DbContextOptions<FoodHeavenDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<ContactMessage> ContactMessages { get; set; }

    public virtual DbSet<LoyaltyAccount> LoyaltyAccounts { get; set; }

    public virtual DbSet<LoyaltyTransaction> LoyaltyTransactions { get; set; }

    public virtual DbSet<MenuItem> MenuItems { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Subscriber> Subscribers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.Property(e => e.ReservationType).HasDefaultValue("");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
