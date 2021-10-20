using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Domain.OrderAggregate.Dtos;

namespace Validata.ApplicationServices.Order.Commands.CreateOrderCommand
{
    public class CreateOrderCommand : IRequest<long>
    {
        #region Constructors
        public CreateOrderCommand(CreateOrderDto createOrderDto)
        {
            CreateOrderDto = createOrderDto;
        }

        #endregion

        #region Properties

        public CreateOrderDto CreateOrderDto { get; private set; }

        #endregion
    }
}
