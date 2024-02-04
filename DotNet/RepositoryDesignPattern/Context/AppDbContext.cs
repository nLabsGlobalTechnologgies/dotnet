using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.Interfaces;
using RepositoryDesignPattern.Models;

namespace RepositoryDesignPattern.Context;

public sealed class AppDbContext : DbContext, IUnitOfWork
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Order> Orders { get; set; }
}
