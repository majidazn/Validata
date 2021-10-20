using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Validata.ApplicationServices.Infrastrutures.UnitOfWork;
using Validata.Domain.CustomerAggregate.Repositories;

namespace Validata.ApplicationServices.Customer.Commands.CreateCustomerCommand
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, long>
    {

        #region Fields

        private readonly ICustomerRepositoryCommand _customerRepositoryCommand;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors
        public CreateCustomerCommandHandler(ICustomerRepositoryCommand customerRepositoryCommand, IUnitOfWork unitOfWork)
        {
            _customerRepositoryCommand = customerRepositoryCommand;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<long> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await Domain.CustomerAggregate.Entities.Customer.Create(
                request.CreateCustomerDto.FirstName,
                request.CreateCustomerDto.LastName,
                request.CreateCustomerDto.Address,
                request.CreateCustomerDto.PostalCode
                );

            await _customerRepositoryCommand.CreateAsync(customer, cancellationToken);
            await _unitOfWork.CompleteAsync();
            return customer.Id;
        }
    }
}
