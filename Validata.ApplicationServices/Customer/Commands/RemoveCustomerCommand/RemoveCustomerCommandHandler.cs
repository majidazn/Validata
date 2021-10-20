using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Validata.ApplicationServices.Infrastrutures.UnitOfWork;
using Validata.Domain.CustomerAggregate.Repositories;

namespace Validata.ApplicationServices.Customer.Commands.RemoveCustomerCommand
{
    public class RemoveCustomerCommandHandler : IRequestHandler<RemoveCustomerCommand, bool>
    {
        #region Fields

        private readonly ICustomerRepositoryCommand _customerRepositoryCommand;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors
        public RemoveCustomerCommandHandler(ICustomerRepositoryCommand customerRepositoryCommand, IUnitOfWork unitOfWork)
        {
            _customerRepositoryCommand = customerRepositoryCommand;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<bool> Handle(RemoveCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepositoryCommand.GetCustomerById(request.CustomerId, cancellationToken);
            customer.RemoveCustomer();
            return (await _unitOfWork.CompleteAsync()) > 0;
        }
      
    }
}
