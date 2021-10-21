using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Validata.ApplicationServices.Infrastrutures.UnitOfWork;
using Validata.Domain.OrderAggregate.DomainServices;
using Validata.Domain.OrderAggregate.Repositories;

namespace Validata.ApplicationServices.Order.Commands.EditOrderCommand
{
    public class EditOrderCommandHandler : IRequestHandler<EditOrderCommand, bool>
    {
        #region Fields

        private readonly IOrderRepositoryCommand _orderRepositoryCommand;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderDomainServices _orderDomainServices;

        #endregion

        #region Constructors
        public EditOrderCommandHandler(IOrderRepositoryCommand orderRepositoryCommand, IUnitOfWork unitOfWork,
            IOrderDomainServices orderDomainServices)
        {
            _orderRepositoryCommand = orderRepositoryCommand;
            _unitOfWork = unitOfWork;
            _orderDomainServices = orderDomainServices;
        }
        #endregion
        public async Task<bool> Handle(EditOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepositoryCommand.FetchOrderAggregate(request.EditOrderDto.Id, cancellationToken);

            await order.EditOrder(_orderDomainServices,
                   request.EditOrderDto.OrderItems
                   );

            return (await _unitOfWork.CompleteAsync()) > 0;
        }
    }
}
