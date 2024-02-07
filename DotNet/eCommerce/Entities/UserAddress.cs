using eCommerce.Abstractions;

namespace eCommerce.Entities;

public sealed class UserAddress : Entity
{
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}
