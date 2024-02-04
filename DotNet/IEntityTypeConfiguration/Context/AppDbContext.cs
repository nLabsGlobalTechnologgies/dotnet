using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IEntityTypeConfiguration.Context;

public sealed class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder
            //.UseLazyLoadingProxies()
            .UseSqlServer("")
            .LogTo(Console.WriteLine, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration<Product>(new ProductConfiguration());
        //modelBuilder.ApplyConfiguration<Category>(new CategoryConfiguration());

        //modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        //yukarıda manuel yapılır işlemler aşagıda ise Assembly üzerinden yapılmaktadır Configuration dosyalarının dahil edilme işlemi
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
