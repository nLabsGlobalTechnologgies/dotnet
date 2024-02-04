using IEntityTypeConfiguration.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IEntityTypeConfiguration.ModelConfigurations;

public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.Property(p => p.Id).HasColumnType("varchar(100)");

        builder.Property(p => p.Name).IsRequired().HasColumnType("varchar(100)");
        builder.HasIndex(x => x.Name).IsUnique();

        builder.HasMany(p => p.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

    }
}
