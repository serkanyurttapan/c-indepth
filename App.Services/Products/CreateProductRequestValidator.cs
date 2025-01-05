using FluentValidation;

namespace Services.Products;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Price).NotNull().GreaterThan(0).WithMessage("Price must be greater than 0");
        RuleFor(x => x.Stock).NotNull().GreaterThan(0).WithMessage("Stock must be greater than 0");
    }
}