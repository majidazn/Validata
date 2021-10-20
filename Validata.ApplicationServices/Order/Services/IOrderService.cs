using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Domain.OrderAggregate.Dtos;

namespace Validata.ApplicationServices.Order.Services
{
   public interface IOrderService
    {
        Task<List<OrderResultSearchDto>> GetOrders();
    }
}
