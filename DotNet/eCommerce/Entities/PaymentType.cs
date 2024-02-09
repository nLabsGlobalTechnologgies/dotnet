using eCommerce.Abstractions;

namespace eCommerce.Entities;

public sealed class PaymentType : Entity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public IEnumerable<OrderPaymentType>? Orders { get; set; }
}
