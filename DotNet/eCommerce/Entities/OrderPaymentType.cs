namespace eCommerce.Entities;

public sealed class OrderPaymentType
{
    public Guid OrderId { get; set; }
    public Order? Order { get; set; }
    public Guid PaymentTypeId { get; set; }
    public PaymentType? PaymentType { get; set; }
}
