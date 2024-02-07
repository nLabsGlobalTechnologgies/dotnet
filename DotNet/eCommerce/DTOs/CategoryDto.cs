namespace eCommerce.DTOs;

public sealed record AddCategoryDto(
    string Name,
    string Icon,
    string? Description);

public sealed record UpdateCategoryDto(
    Guid Id,
    string Name,
    string Icon,
    string? Description);
public sealed record DeleteCategoryDto(
    Guid Id);