using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validata.Domain.OrderAggregate.Dtos
{
    public class OrderResultSearchDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CustomerFullName { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public List<CreateOrderItemDto> OrderItems { get; set; }
    }
}
