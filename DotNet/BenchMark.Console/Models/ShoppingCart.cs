namespace BenchMark.Console.Models;
public sealed class ShoppingCart
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }

    public int Quantity { get; set; }
}
