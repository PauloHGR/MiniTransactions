using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Product.Create
{
    public sealed class CreateUserValidation : AbstractValidator<CreateProductRequest>
    {
        public CreateUserValidation() { 
            RuleFor(p => p.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(p => p.Price).NotEmpty();
        }
    }
}
