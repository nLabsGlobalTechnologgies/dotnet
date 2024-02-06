using eCommerce.Abstractions;

namespace eCommerce.Entities;

public sealed class Product : Entity
{
    public string Name { get; set; } = string.Empty;
    public string? Title { get; set; }
    public Guid CategoryId { get; set; }
}
