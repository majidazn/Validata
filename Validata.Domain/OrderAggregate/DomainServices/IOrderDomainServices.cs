using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Validata.Domain.OrderAggregate.DomainServices
{
    public interface IOrderDomainServices
    {
        Task<decimal> GetProductsTotalPrice(List<int> productIs);
    }
}
