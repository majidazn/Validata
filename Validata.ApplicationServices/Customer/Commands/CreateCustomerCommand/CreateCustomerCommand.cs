using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Domain.CustomerAggregate.Dtos;

namespace Validata.ApplicationServices.Customer.Commands.CreateCustomerCommand
{
    public class CreateCustomerCommand : IRequest<long>
    {
        #region Constructors
        public CreateCustomerCommand(CreateCustomerDto createCustomerDto)
        {
            CreateCustomerDto = createCustomerDto;
        }

        #endregion

        #region Properties

        public CreateCustomerDto CreateCustomerDto { get; private set; }

        #endregion
    }
}
