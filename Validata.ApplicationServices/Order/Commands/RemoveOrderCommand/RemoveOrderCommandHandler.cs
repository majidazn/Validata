using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Validata.ApplicationServices.Infrastrutures.UnitOfWork;
using Validata.Domain.OrderAggregate.Repositories;

namespace Validata.ApplicationServices.Order.Commands.RemoveOrderCommand
{
    public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommand, bool>
    {
        #region Fields

        private readonly IOrderRepositoryCommand _orderRepositoryCommand;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors
        public RemoveOrderCommandHandler(IOrderRepositoryCommand orderRepositoryCommand, IUnitOfWork unitOfWork)
        {
            _orderRepositoryCommand = orderRepositoryCommand;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<bool> Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
        {
            var customer = await _orderRepositoryCommand.GetOrderById(request.OrderId, cancellationToken);
            customer.RemoveOrder();
            return (await _unitOfWork.CompleteAsync()) > 0;
        }
    }
}
