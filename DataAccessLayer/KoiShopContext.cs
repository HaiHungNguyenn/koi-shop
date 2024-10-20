﻿using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer;

public class KoiShopContext : DbContext
{
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<KoiCategory> KoiCategories { get; set; }
    public DbSet<KoiFish> KoiFishes { get; set; }
    public DbSet<KoiImage> KoiImages { get; set; }
    public DbSet<KoiPackage> KoiPackages{ get; set; }
    public DbSet<LoyaltyPoint> LoyaltyPoints{ get; set; }
    public DbSet<Order> Orders{ get; set; }
    public DbSet<OrderDetail> OrderDetails{ get; set; }
    public DbSet<OrderPromotion> OrderPromotions{ get; set; }
    public DbSet<Payment> Payments{ get; set; }
    public DbSet<Promotion> Promotions{ get; set; }
    public DbSet<Role> Roles{ get; set; }
    public DbSet<Shipment> Shipments{ get; set; }
    public DbSet<User> Users{ get; set; }

    public KoiShopContext()
    {
        
    }
    
    public KoiShopContext(DbContextOptions<KoiShopContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
            return;
        optionsBuilder.UseSqlServer(GetConnectionString());
        base.OnConfiguring(optionsBuilder);
    }

    private string GetConnectionString() { 
        IConfiguration conf = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        return conf.GetConnectionString("DefaultConnection");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Shipment)
            .WithOne(s => s.Order)
            .HasForeignKey<Shipment>(s => s.OrderId);
        base.OnModelCreating(modelBuilder);
    }
}