using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Validata.Domain.CustomerAggregate.Repositories;
using Validata.Domain.OrderAggregate.Dtos;
using Validata.Domain.OrderAggregate.Repositories;
using Validata.Domain.ProductAggregate.Repositories;

namespace Validata.ApplicationServices.Order.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepositoryQuery _orderRepositoryQuery;
        private readonly IProductRepositoryQuery _productRepositoryQuery;
        private readonly ICustomerRepositoryQuery _customerRepositoryQuery;


        public OrderService(IOrderRepositoryQuery orderRepositoryQuery, IProductRepositoryQuery productRepositoryQuery,
            ICustomerRepositoryQuery customerRepositoryQuery
            )

        {
            _orderRepositoryQuery = orderRepositoryQuery;
            _productRepositoryQuery = productRepositoryQuery;
            _customerRepositoryQuery = customerRepositoryQuery;
        }


        public async Task<List<OrderResultSearchDto>> GetOrders()
        {
            var orders = _orderRepositoryQuery.GetOrders();

            var productIds = orders.SelectMany(s => s.OrderItems).Select(s => s.ProductId).ToList();

            var products =await _productRepositoryQuery.GetProductsByIds(productIds);

            var customerIds= orders.Select(s=>s.CustomerId).ToList();
            var customers = await _customerRepositoryQuery.GetCustomersByIds(customerIds);


            var orderList = new List<OrderResultSearchDto>();


            foreach (var item in orders)
            {
                orderList.Add(new OrderResultSearchDto
                {
                    Id = item.Id,
                    CustomerId= item.CustomerId,
                    CustomerFullName= customers.FirstOrDefault(q=>q.Id==item.CustomerId).FullName,
                    OrderDate= item.OrderDate,
                    TotalPrice= item.TotalPrice.Value,
                    OrderItems= item.OrderItems.Select(s=>new OrderItemDto() 
                    {
                        Id=s.Id,
                        OrderId=s.OrderId,
                        ProductId=s.ProductId,
                        Quantity= s.Quantity,
                        ProductName= products.FirstOrDefault(q=>q.Id== s.ProductId).Name,
                        ProductPrice = products.FirstOrDefault(q => q.Id == s.ProductId).Price,
                    }).ToList()

                });
            }

            return orderList.OrderByDescending(o=>o.OrderDate).ToList();

        }
    }
}
