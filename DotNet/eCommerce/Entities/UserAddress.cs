namespace eCommerce.Entities;

public sealed class UserAddress
{
    public Guid UserId { get; set; }
    public AppUser? User { get; set; }
    public Guid AddressId { get; set; }
    public Address? Address { get; set; }
}
