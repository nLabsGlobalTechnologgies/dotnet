using RepositoryDesignPattern.Abstractions;

namespace RepositoryDesignPattern.Models;

public sealed class User : Entity
{
    public string Name { get; set; } = string.Empty;
}
