using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Domain.ProductAggregate.Dtos;

namespace Validata.Domain.ProductAggregate.Repositories
{
    public interface IProductRepositoryQuery
    {
        Task<List<ProductDto>> GetProductsByIds(List<int> productIds);
    }
}
