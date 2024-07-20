using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ProductCase.Delete
{
    public sealed class DeleteProductValidation : AbstractValidator<DeleteProductRequest>
    {
        public DeleteProductValidation() {
            RuleFor(p => p.Id).NotEmpty();
        }
    }
}
