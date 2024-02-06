using eCommerce.Abstractions;

namespace eCommerce.Entities;

public sealed class Category : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string? Description { get; set; }
}