using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Domain.CustomerAggregate.Dtos;

namespace Validata.ApplicationServices.Customer.Commands.EditCustomerCommand
{
    public class EditCustomerCommand : IRequest<bool>
    {
        #region Constructors
        public EditCustomerCommand(CreateCustomerDto editCustomerDto)
        {
            EditCustomerDto = editCustomerDto;
        }
        #endregion

        #region Properties
        public CreateCustomerDto EditCustomerDto { get; private set; }
        #endregion
    }
}
