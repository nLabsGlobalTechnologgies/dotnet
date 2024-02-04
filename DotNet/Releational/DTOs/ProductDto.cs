namespace Releational.DTOs;

public sealed record AddProductDto(
    string ProductName,
    string ProductDescription,
    decimal ProductPrice,
    string CategoryName);
