using eCommerce.Abstractions;

namespace eCommerce.Entities;

public class Address : Entity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}
