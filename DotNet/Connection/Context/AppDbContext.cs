using Connection.Models;
using Microsoft.EntityFrameworkCore;

namespace Connection.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<Personel>? Employees { get; set; }
}
