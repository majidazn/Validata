using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Common.IRepository;

namespace Validata.Domain.ProductAggregate.Repositories
{
    public interface IProductRepositoryCommand : IRepository<Entities.Product>
    {
    }
}
