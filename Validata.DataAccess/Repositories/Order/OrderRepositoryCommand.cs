using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Validata.Common.Repository;
using Validata.DataAccess.Context;
using Validata.Domain.OrderAggregate.Repositories;

namespace Validata.DataAccess.Repositories.Order
{
    public class OrderRepositoryCommand : Repository<Domain.OrderAggregate.Entities.Order>, IOrderRepositoryCommand
    {
        private readonly ECommerceBoundedContextCommand _eCommerceBoundedContextCommand;
        public OrderRepositoryCommand(ECommerceBoundedContextCommand dbContext, IHttpContextAccessor httpContextAccessor = null)
            : base(dbContext, httpContextAccessor)
        {
            _eCommerceBoundedContextCommand = dbContext;
        }

        public async Task<Domain.OrderAggregate.Entities.Order> FetchOrderAggregate(long orderId, CancellationToken cancellationToken)
        {
            return await _eCommerceBoundedContextCommand.Orders.
                Include(i => i.OrderItems).
                FirstOrDefaultAsync(e => e.Id == orderId, cancellationToken);
        }
        public async Task<Domain.OrderAggregate.Entities.Order> GetOrderById(long orderId, CancellationToken cancellationToken)
        {
            return await _eCommerceBoundedContextCommand.Orders.FirstOrDefaultAsync(q => q.Id == orderId, cancellationToken);
        }
        public async Task<decimal> GetProductsTotalPrice(List<int> productIs )
        {
            return await _eCommerceBoundedContextCommand.Products.Where(q => productIs.Contains(q.Id)).SumAsync(s => s.Price.Value);
        }

    }
}
