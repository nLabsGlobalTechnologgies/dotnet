namespace RepositoryDesignPattern.DTOs;

public sealed record AddShoppingCartDto(
    int ProductId,
    int Quantity);