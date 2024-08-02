using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.CustomerCase.Create
{
    public sealed class CreateCustomerValidation : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerValidation() {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(50).MinimumLength(5);
            RuleFor(c => c.Email).NotEmpty().EmailAddress();
            RuleFor(c => c.CPF).NotEmpty().Length(11, 11);
            RuleFor(c => c.Password).NotEmpty().MinimumLength(8);
        }
    }
}
