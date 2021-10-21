using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Validata.Common.IRepository;
using Validata.Domain.ProductAggregate.Dtos;

namespace Validata.Domain.OrderAggregate.Repositories
{
    public interface IOrderRepositoryCommand : IRepository<Entities.Order>
    {
        Task<Domain.OrderAggregate.Entities.Order> FetchOrderAggregate(long orderId, CancellationToken cancellationToken);
        Task<Domain.OrderAggregate.Entities.Order> GetOrderById(long orderId, CancellationToken cancellationToken);
        Task<decimal> GetProductsTotalPrice(List<ProductDto> productDtos);
    }
}
