using eCommerce.Abstractions;

namespace eCommerce.Entities;

public sealed class AppUser : Entity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public IEnumerable<Product>? Products { get; set; }
    public IEnumerable<Order>? Orders { get; set; }
}
