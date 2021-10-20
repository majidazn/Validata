using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.DataAccess.Context;
using Validata.Domain.ProductAggregate.Dtos;
using Validata.Domain.ProductAggregate.Repositories;

namespace Validata.DataAccess.Repositories.Product
{
    public class ProductRepositoryQuery: IProductRepositoryQuery
    {
        #region Fields
        private readonly ECommerceBoundedContextQuery _context;
        #endregion
        #region Constructors
        public ProductRepositoryQuery(ECommerceBoundedContextQuery eCommerceBoundedContextQuery)
        {
            _context = eCommerceBoundedContextQuery;
        }
        #endregion

        #region Methods

        public async Task<List<ProductDto>> GetProductsByIds(List<int> productIds)
        {
            var query =await (from p in _context.Products
                         where productIds.Contains(p.Id)
                         select new ProductDto
                         {
                             Id = p.Id,
                             Name = p.Name,
                             Price=p.Price.Value
                         }).ToListAsync();
            return query;
        } 

        #endregion
    }
}
