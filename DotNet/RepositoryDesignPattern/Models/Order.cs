using RepositoryDesignPattern.Abstractions;

namespace RepositoryDesignPattern.Models;

public sealed class Order : Entity
{
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
}
