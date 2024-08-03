using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.CustomerCase.GetAll
{
    public class GetAllCustomersValidation : AbstractValidator<GetAllCustomersRequest>
    {
        public GetAllCustomersValidation() {
            RuleFor(c => c.Email).EmailAddress();
            RuleFor(c => c.CPF).Length(11, 11);
        }
    }
}
