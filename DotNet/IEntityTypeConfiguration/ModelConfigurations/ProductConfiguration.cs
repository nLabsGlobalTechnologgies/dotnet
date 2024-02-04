using IEntityTypeConfiguration.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IEntityTypeConfiguration.ModelConfigurations;

public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.Property(p => p.Id).HasColumnType("varchar(100)");
        builder.Property(p => p.CategoryId).HasColumnType("varchar(100)");

        builder.Property(p => p.Name).IsRequired().HasColumnType("varchar(100)");
        builder.HasIndex(p => p.Name).IsUnique();

        builder.HasOne(p => p.Category)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
