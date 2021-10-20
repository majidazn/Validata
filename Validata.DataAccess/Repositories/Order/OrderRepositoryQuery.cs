using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.DataAccess.Context;
using Validata.Domain.OrderAggregate.Repositories;

namespace Validata.DataAccess.Repositories.Order
{
    public class OrderRepositoryQuery : IOrderRepositoryQuery
    {
        #region Fields
        private readonly ECommerceBoundedContextQuery _context;
        #endregion
        #region Constructors
        public OrderRepositoryQuery(ECommerceBoundedContextQuery eCommerceBoundedContextQuery)
        {
            _context = eCommerceBoundedContextQuery;
        }
        #endregion

        #region Methods
        public IQueryable<Domain.OrderAggregate.Entities.Order> GetOrders()
        {
            var orders = from x in _context.Orders
                           .Include(i=>i.OrderItems)
                           select x;

            return orders;
        }
        #endregion
    }
}
