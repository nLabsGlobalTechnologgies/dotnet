using eCommerce.Abstractions;

namespace eCommerce.Entities;

public sealed class Order : Entity
{
    public Guid UserId { get; set; }
    public Guid UserAddressId { get; set; }
    public Guid PaymentTypeId { get; set; }
    public decimal TotalPrice { get; set; } = 0;
    public IEnumerable<OrderDetail>? Details { get; set; }
}
