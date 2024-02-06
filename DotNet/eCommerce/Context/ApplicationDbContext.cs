using Microsoft.EntityFrameworkCore;
using eCommerce.Entities;

namespace eCommerce.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

public DbSet<eCommerce.Entities.Category> Category { get; set; } = default!;
}
