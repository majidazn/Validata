using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validata.Domain.OrderAggregate.Repositories
{
    public interface IOrderRepositoryQuery
    {
        IQueryable<Domain.OrderAggregate.Entities.Order> GetOrders();
    }
}
