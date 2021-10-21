using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Validata.Domain.ProductAggregate.Dtos;

namespace Validata.Domain.OrderAggregate.DomainServices
{
    public interface IOrderDomainServices
    {
        Task<decimal> GetProductsTotalPrice(List<ProductDto> productDtos);
    }
}
