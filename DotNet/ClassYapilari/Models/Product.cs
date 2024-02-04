namespace ClassYapilari.Models;

public sealed class Product
{
    public Product(string name, int quantity, decimal price)
    {
        Name = name;
        Quantity = quantity;
        Price = price;
    }
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
