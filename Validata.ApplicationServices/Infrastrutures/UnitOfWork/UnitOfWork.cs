using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Validata.DataAccess.Context;
using Validata.DataAccess.Repositories.Customer;
using Validata.Domain.CustomerAggregate.Repositories;
using Validata.Domain.OrderAggregate.Repositories;
using Validata.Domain.ProductAggregate.Repositories;

namespace Validata.ApplicationServices.Infrastrutures.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ECommerceBoundedContextCommand _context;
       // private readonly ILogger _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

       public ICustomerRepositoryCommand Customer { get; private set; }
       public IOrderRepositoryCommand Order { get; private set; }
       public IProductRepositoryCommand Product { get; private set; }


        public UnitOfWork(ECommerceBoundedContextCommand context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            //_logger = loggerFactory.CreateLogger("logs");

          
            _httpContextAccessor = httpContextAccessor;
            Customer = new CustomerRepositoryCommand(context, httpContextAccessor);
        }

        public async Task<int> CompleteAsync()
        {
           return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
