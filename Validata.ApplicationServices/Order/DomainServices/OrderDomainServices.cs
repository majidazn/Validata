using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Validata.Domain.OrderAggregate.DomainServices;
using Validata.Domain.OrderAggregate.Repositories;

namespace Validata.ApplicationServices.Order.DomainServices
{
    public class OrderDomainServices : IOrderDomainServices
    {
        private readonly IOrderRepositoryCommand _orderRepositoryCommand;

        public OrderDomainServices(IOrderRepositoryCommand orderRepositoryCommand)
        {
            _orderRepositoryCommand = orderRepositoryCommand;
        }
        public async Task<decimal> GetProductsTotalPrice(List<int> productIs)
        {
            return await _orderRepositoryCommand.GetProductsTotalPrice(productIs);
        }
    }
}
