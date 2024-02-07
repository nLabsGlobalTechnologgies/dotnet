using Microsoft.EntityFrameworkCore;
using eCommerce.Entities;

namespace eCommerce.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<AppUser>? Users { get; set; }
    public DbSet<UserAddress>? UserAddresses { get; set; }
    public DbSet<PaymentType>? PaymentTypes { get; set; }
    public DbSet<Category>? Category { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<Order>? Orders { get; set; }
    public DbSet<OrderDetail>? OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired();

        modelBuilder.Entity<Category>().HasOne(c => c.Products);

        modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("money");
    }
}
