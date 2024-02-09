using eCommerce.Abstractions;

namespace eCommerce.Entities;

public sealed class Order : Entity
{
    public Guid UserId { get; set; }
    public AppUser? User { get; set; }
    public Guid UserAddressId { get; set; }
    public UserAddress? Address { get; set; }
    public IEnumerable<OrderPaymentType>? OrderPaymentTypes { get; set; }
    public decimal TotalPrice { get; set; } = 1;
    public IEnumerable<OrderDetail>? Details { get; set; }
}
