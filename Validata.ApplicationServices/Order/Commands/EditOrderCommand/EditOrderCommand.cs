using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Domain.OrderAggregate.Dtos;

namespace Validata.ApplicationServices.Order.Commands.EditOrderCommand
{
   public class EditOrderCommand : IRequest<bool>
    {
        #region Constructors
        public EditOrderCommand(CreateOrderDto editOrderDto)
        {
            EditOrderDto = editOrderDto;
        }
        #endregion

        #region Properties
        public CreateOrderDto EditOrderDto { get; private set; }
        #endregion
    }
}
