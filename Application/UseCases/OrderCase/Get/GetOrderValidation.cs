using FluentValidation;

namespace Application.UseCases.OrderCase.Get
{
    public class GetOrderValidation : AbstractValidator<GetOrderRequest>
    {
        public GetOrderValidation() { 
            RuleFor(o => o.CPF).Length(11,11);
        }
    }
}
