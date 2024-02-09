using eCommerce.Abstractions;

namespace eCommerce.Entities;

public sealed class Product : Entity
{
    public Guid UserId { get; set; }
    public AppUser? User { get; set; }
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Title { get; set; }
    public decimal Price { get; set; } = 1;
    public int Quantity { get; set; } = 1;
    public decimal? Discount { get; set; }
}
