using FluentValidation;

namespace Validata.ApplicationServices.Order.Commands.EditOrderCommand
{
   public class EditOrderCommandValidator : AbstractValidator<EditOrderCommand>
    {
        public EditOrderCommandValidator()
        {
            RuleFor(i => i.EditOrderDto.Id).GreaterThan(0).WithMessage("OrderId is required !");

        }
    }
}
