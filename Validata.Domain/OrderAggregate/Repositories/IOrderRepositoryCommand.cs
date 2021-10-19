using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Common.IRepository;

namespace Validata.Domain.OrderAggregate.Repositories
{
    public interface IOrderRepositoryCommand : IRepository<Entities.Order>
    {
    }
}
