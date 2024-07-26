using FluentValidation;

namespace Application.UseCases.ProductCase.GetAll
{
    public sealed class GetAllProductValidation : AbstractValidator<GetAllProductRequest>
    {
        public GetAllProductValidation() {
            RuleFor(p => p.Quantity).GreaterThan(-1);
            RuleFor(p => p.Price).GreaterThan(-1);
        }
    }
}
