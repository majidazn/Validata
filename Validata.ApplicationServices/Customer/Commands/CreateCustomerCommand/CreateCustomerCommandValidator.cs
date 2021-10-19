using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validata.ApplicationServices.Customer.Commands.CreateCustomerCommand
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(i => i.CreateCustomerDto.FirstName).NotEmpty().NotNull().WithMessage("FirstName is required !");
            RuleFor(i => i.CreateCustomerDto.FirstName).MaximumLength(50).WithMessage("Maximum length for firstName is 50 character!");

            RuleFor(i => i.CreateCustomerDto.LastName).NotEmpty().NotNull().WithMessage("LastName is required !");
            RuleFor(i => i.CreateCustomerDto.LastName).MaximumLength(50).WithMessage("Maximum length for LastName is 50 character!");

            RuleFor(i => i.CreateCustomerDto.Address).NotEmpty().NotNull().WithMessage("LastName is required !");
            RuleFor(i => i.CreateCustomerDto.Address).MaximumLength(200).WithMessage("Maximum length for Address is 200 character!");

            RuleFor(i => i.CreateCustomerDto.PostalCode).NotEmpty().NotNull().WithMessage("PostalCode is required !");
            RuleFor(i => i.CreateCustomerDto.PostalCode).MaximumLength(200).WithMessage("Maximum length for PostalCode is 6 character!");

        }
    }
}
