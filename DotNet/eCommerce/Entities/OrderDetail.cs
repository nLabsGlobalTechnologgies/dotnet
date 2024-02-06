using eCommerce.Abstractions;

namespace eCommerce.Entities;

public sealed class OrderDetail : Entity
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public byte Quantity { get; set; } = 1;
    public decimal Amount { get; set; } = 0;
    public decimal UnitPrice { get; set; } = 0;
}
