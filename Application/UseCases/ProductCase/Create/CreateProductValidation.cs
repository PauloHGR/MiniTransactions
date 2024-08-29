using FluentValidation;

namespace Application.UseCases.Product.Create
{
    public sealed class CreateProductValidation : AbstractValidator<CreateProductRequest>
    {
        public CreateProductValidation() { 
            RuleFor(p => p.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(p => p.Price).NotEmpty().GreaterThan(1);
            RuleFor(p => p.Quantity).NotEmpty().GreaterThan(0);
        }
    }
}
