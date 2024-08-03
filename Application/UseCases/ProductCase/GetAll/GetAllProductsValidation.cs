using FluentValidation;

namespace Application.UseCases.ProductCase.GetAll
{
    public sealed class GetAllProductsValidation : AbstractValidator<GetAllProductsRequest>
    {
        public GetAllProductsValidation() {
            RuleFor(p => p.Quantity).GreaterThan(-1);
            RuleFor(p => p.Price).GreaterThan(-1);
        }
    }
}
