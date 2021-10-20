using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.DataAccess.Context;
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
        #endregion
    }
}
