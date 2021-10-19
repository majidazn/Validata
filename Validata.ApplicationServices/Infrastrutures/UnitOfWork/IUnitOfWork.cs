using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Validata.Domain.CustomerAggregate.Repositories;
using Validata.Domain.OrderAggregate.Repositories;
using Validata.Domain.ProductAggregate.Repositories;

namespace Validata.ApplicationServices.Infrastrutures.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepositoryCommand Customer { get; }
        IOrderRepositoryCommand Order { get; }
        IProductRepositoryCommand Product { get; }

        Task CompleteAsync();
    }
}
