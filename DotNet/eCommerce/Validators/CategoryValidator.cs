using eCommerce.DTOs;
using FluentValidation;

namespace eCommerce.Validators;

public sealed class AddCategoryDtoValidator : AbstractValidator<AddCategoryDto>
{
    public AddCategoryDtoValidator()
    {
        RuleFor(c => c.Name).NotEmpty().NotNull().WithMessage("Kategori Adı Boş Olamaz");
    }
}
