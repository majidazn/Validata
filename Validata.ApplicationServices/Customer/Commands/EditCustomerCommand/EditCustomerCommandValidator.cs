using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validata.ApplicationServices.Customer.Commands.EditCustomerCommand
{
    public class EditCustomerCommandValidator : AbstractValidator<EditCustomerCommand>
    {
        public EditCustomerCommandValidator()
        {
            RuleFor(i => i.EditCustomerDto.FirstName).NotEmpty().NotNull().WithMessage("FirstName is required !");
            RuleFor(i => i.EditCustomerDto.FirstName).MaximumLength(50).WithMessage("Maximum length for firstName is 50 character!");

            RuleFor(i => i.EditCustomerDto.LastName).NotEmpty().NotNull().WithMessage("LastName is required !");
            RuleFor(i => i.EditCustomerDto.LastName).MaximumLength(50).WithMessage("Maximum length for LastName is 50 character!");

            RuleFor(i => i.EditCustomerDto.Address).NotEmpty().NotNull().WithMessage("LastName is required !");
            RuleFor(i => i.EditCustomerDto.Address).MaximumLength(200).WithMessage("Maximum length for Address is 200 character!");

            RuleFor(i => i.EditCustomerDto.PostalCode).NotEmpty().NotNull().WithMessage("PostalCode is required !");
            RuleFor(i => i.EditCustomerDto.PostalCode).MaximumLength(200).WithMessage("Maximum length for PostalCode is 6 character!");

        }
    }
}
