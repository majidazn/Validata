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
using Validata.Domain.ProductAggregate.Repositories;

namespace Validata.DataAccess.Repositories.Product
{
    public class ProductRepositoryCommand : Repository<Domain.ProductAggregate.Entities.Product>, IProductRepositoryCommand
    {
        private readonly ECommerceBoundedContextCommand _eCommerceBoundedContextCommand;
        public ProductRepositoryCommand(ECommerceBoundedContextCommand dbContext, IHttpContextAccessor httpContextAccessor = null)
            : base(dbContext, httpContextAccessor)
        {
            _eCommerceBoundedContextCommand = dbContext;
        }

        public async Task<Domain.ProductAggregate.Entities.Product> FetchProductAggregate(long productId, CancellationToken cancellationToken)
        {
            return await _eCommerceBoundedContextCommand.Products.
                FirstOrDefaultAsync(e => e.Id == productId, cancellationToken);
        }
        public async Task<Domain.ProductAggregate.Entities.Product> GetProductById(long productId, CancellationToken cancellationToken)
        {
            return await _eCommerceBoundedContextCommand.Products.FirstOrDefaultAsync(q => q.Id == productId, cancellationToken);
        }
    }
}
