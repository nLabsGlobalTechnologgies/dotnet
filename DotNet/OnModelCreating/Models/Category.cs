using OnModelCreating.Abstractions;

namespace OnModelCreating.Models;

public sealed class Category : Entity
{
    public string Name { get; set; } = string.Empty;
    //public List<Product>? Products { get; set; }

    // bu şekilde yapılırsa cycle hatası yeriz çözüm ya product tablosundaki ilgili kısmı kaldırmak yada bu kısmı kaldırmak aksi halde cycle hatası alacagız.
}
