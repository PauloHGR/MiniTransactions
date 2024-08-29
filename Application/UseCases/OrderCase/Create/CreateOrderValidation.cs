using FluentValidation;

namespace Application.UseCases.OrderCase.Create
{
    public sealed class CreateOrderValidation : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderValidation() {
            RuleFor(o => o.Quantity).GreaterThan(0);
        }
    }
}
