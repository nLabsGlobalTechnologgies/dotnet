using Microsoft.EntityFrameworkCore;
using NewRepositoryDesignPattern.Interfaces;
using NewRepositoryDesignPattern.Models;

namespace NewRepositoryDesignPattern.Context;

public sealed class AppDbContext : DbContext, IUnitOfWork
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Category>? Categories { get; set; }
}
