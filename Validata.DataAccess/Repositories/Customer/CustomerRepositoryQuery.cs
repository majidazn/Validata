using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.DataAccess.Context;
using Validata.Domain.CustomerAggregate.Dtos;
using Validata.Domain.CustomerAggregate.Repositories;

namespace Validata.DataAccess.Repositories.Customer
{
    public class CustomerRepositoryQuery : ICustomerRepositoryQuery
    {
        #region Fields
        private readonly ECommerceBoundedContextQuery _context;
        #endregion
        #region Constructors
        public CustomerRepositoryQuery(ECommerceBoundedContextQuery eCommerceBoundedContextQuery)
        {
            _context = eCommerceBoundedContextQuery;
        }
        #endregion

        #region Methods
        public IQueryable<Domain.CustomerAggregate.Entities.Customer> GetCustomers()
        {
            var customer = from x in _context.Customers
                          select x;

            return customer;
        }



        public async Task<List<CustomerDto>> GetCustomersByIds(List<int> customerIds)
        {
            var query = await (from c in _context.Customers
                               where customerIds.Contains(c.Id)
                               select new CustomerDto
                               {
                                   Id = c.Id,
                                  FullName= c.FirstName+" "+ c.LastName
                               }).ToListAsync();
            return query;
        }
        #endregion
    }
}
