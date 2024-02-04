using OnModelCreating.Abstractions;

namespace OnModelCreating.Models;

public sealed class Product : Entity
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
    // bu şekilde yapılırsa cycle hatası yeriz çözüm ya category tablosundaki ilgili kısmı kaldırmak yada bu kısmı kaldırmak aksi halde cycle hatası alacagız.
}
