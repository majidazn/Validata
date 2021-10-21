using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Validata.ApplicationServices.Infrastrutures.UnitOfWork;
using Validata.Domain.OrderAggregate.DomainServices;
using Validata.Domain.OrderAggregate.Repositories;

namespace Validata.ApplicationServices.Order.Commands.CreateOrderCommand
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, long>
    {


        #region Fields

        private readonly IOrderRepositoryCommand _orderRepositoryCommand;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderDomainServices _orderDomainServices;

        #endregion

        #region Constructors
        public CreateOrderCommandHandler(IOrderRepositoryCommand orderRepositoryCommand, IUnitOfWork unitOfWork,
            IOrderDomainServices orderDomainServices)
        {
            _orderRepositoryCommand = orderRepositoryCommand;
            _unitOfWork = unitOfWork;
            _orderDomainServices = orderDomainServices;
        }
        #endregion

        public async Task<long> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await Domain.OrderAggregate.Entities.Order.Create(_orderDomainServices,
                request.CreateOrderDto.CustomerId,
                request.CreateOrderDto.OrderItems
                );

            await _orderRepositoryCommand.CreateAsync(order, cancellationToken);
            await _unitOfWork.CompleteAsync();
            return order.Id;

        }
    }
}
