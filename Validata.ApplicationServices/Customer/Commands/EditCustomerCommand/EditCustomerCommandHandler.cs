using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Validata.ApplicationServices.Infrastrutures.UnitOfWork;
using Validata.Domain.CustomerAggregate.Repositories;

namespace Validata.ApplicationServices.Customer.Commands.EditCustomerCommand
{
    public class EditCustomerCommandHandler : IRequestHandler<EditCustomerCommand, bool>
    {


        #region Fields

        private readonly ICustomerRepositoryCommand _customerRepositoryCommand;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors
        public EditCustomerCommandHandler(ICustomerRepositoryCommand customerRepositoryCommand, IUnitOfWork unitOfWork)
        {
            _customerRepositoryCommand = customerRepositoryCommand;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<bool> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepositoryCommand.FetchCustomerAggregate(request.EditCustomerDto.Id, cancellationToken);

            customer.EditCustomer(
                request.EditCustomerDto.FirstName,
                request.EditCustomerDto.LastName,
                request.EditCustomerDto.Address,
                request.EditCustomerDto.PostalCode
                );

            return (await _unitOfWork.CompleteAsync()) > 0;
        }
    }
}
