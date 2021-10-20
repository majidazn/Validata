using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validata.ApplicationServices.Product.Commands.CreateProductCommand
{
  public  class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(i => i.CreateProductDto.Name).NotEmpty().NotNull().WithMessage("Name is required !");
            RuleFor(i => i.CreateProductDto.Name).MaximumLength(50).WithMessage("Maximum length for Name is 50 character!");

            RuleFor(i => i.CreateProductDto.Price).GreaterThan(0).WithMessage("Price must be greater than zero!");

        }
    }
}
