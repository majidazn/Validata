using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Domain.CustomerAggregate.Dtos;

namespace Validata.Domain.CustomerAggregate.Repositories
{
    public interface ICustomerRepositoryQuery
    {
        IQueryable<Domain.CustomerAggregate.Entities.Customer> GetCustomers();
        Task<List<CustomerDto>> GetCustomersByIds(List<int> customerIds);
    }
}
