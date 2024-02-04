using RepositoryDesignPattern.Abstractions;

namespace RepositoryDesignPattern.Models;

public sealed class Product : Entity
{
    public string Name { get; set; } = string.Empty;
}
