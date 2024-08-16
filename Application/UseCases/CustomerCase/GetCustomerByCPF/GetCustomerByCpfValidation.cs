using FluentValidation;

namespace Application.UseCases.CustomerCase.GetCustomerByCPF
{
    public class GetCustomerByCpfValidation : AbstractValidator<GetCustomerByCPFRequest>
    {
        public GetCustomerByCpfValidation()
        {
            RuleFor(c => c.CPF).NotEmpty().Length(11, 11);
        }
    }
}
