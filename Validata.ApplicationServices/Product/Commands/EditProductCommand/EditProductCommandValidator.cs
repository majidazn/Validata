using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validata.ApplicationServices.Product.Commands.EditProductCommand
{
    public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
    {
        public EditProductCommandValidator()
        {
            RuleFor(i => i.EditProductDto.Name).NotEmpty().NotNull().WithMessage("Name is required !");
            RuleFor(i => i.EditProductDto.Name).MaximumLength(50).WithMessage("Maximum length for Name is 50 character!");

            RuleFor(i => i.EditProductDto.Price).GreaterThan(0).WithMessage("Price must be greater than zero!");

        }
    }
}
