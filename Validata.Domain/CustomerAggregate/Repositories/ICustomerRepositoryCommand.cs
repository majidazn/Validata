using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Validata.Common.IRepository;

namespace Validata.Domain.CustomerAggregate.Repositories
{
   public interface ICustomerRepositoryCommand : IRepository<Entities.Customer>
    {
        Task<Domain.CustomerAggregate.Entities.Customer> FetchCustomerAggregate(long customerId, CancellationToken cancellationToken);
        Task<Domain.CustomerAggregate.Entities.Customer> GetCustomerById(long customerId, CancellationToken cancellationToken);
    }
}
