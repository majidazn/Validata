using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Common.Domain.SeedWork;
using Validata.Common.Enums;
using Validata.Domain.OrderAggregate.DomainServices;
using Validata.Domain.OrderAggregate.Dtos;
using Validata.Domain.OrderAggregate.ValueObjects;

namespace Validata.Domain.OrderAggregate.Entities
{
    public class Order : Entity, IAggregateRoot
    {
        #region Constructor
        public Order()
        {

        }
        private Order(int customerId, DateTime orderDate, decimal totalPrice)
        {
            CustomerId = customerId;
            OrderDate = orderDate;
            TotalPrice = TotalPrice.Create(totalPrice);
            Status = EntityStateType.Default;
        }

        #endregion

        #region Properties
        public new int Id { get; private set; }
        public int CustomerId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public TotalPrice TotalPrice { get; private set; }
        public EntityStateType Status { get; private set; }

        private readonly List<OrderItem> _orderItems = new List<OrderItem>();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();


        #endregion



        #region Behaviors

        public static async Task<Order> Create(IOrderDomainServices orderDomainServices, int customerId,   List<CreateOrderItemDto> orderItems)
        {
            EnforceInvariantsCreate(customerId);
            var productIds = orderItems.Select(s => s.ProductId).ToList();

            var totalPriceCal = await orderDomainServices.GetProductsTotalPrice(productIds);


            var customer = new Order(customerId, DateTime.Now, totalPriceCal);

           
            customer.AddOrderItems(orderItems);



            return customer;
        }

        public async Task EditOrder(IOrderDomainServices orderDomainServices, List<CreateOrderItemDto> orderItems)
        {
            var productIds = orderItems.Select(s => s.ProductId).ToList();

            var totalPriceCal = await orderDomainServices.GetProductsTotalPrice(productIds);



            OrderDate = DateTime.Now;
            TotalPrice = TotalPrice.Create(totalPriceCal);
            EditOrderItems(orderItems);

        }

        public void RemoveOrder()
        {


            Status = EntityStateType.Deleted;
        }

        private decimal CalculateTotalPrce()
        {
            return 0;
        }

        private static void EnforceInvariantsCreate(int customerId)
        {
            if (customerId <= 0)
                throw new Exception("CustomerId is required!");
        }



        private void AddOrderItems(List<CreateOrderItemDto> orderItems)
        {
            foreach (var orderItem in orderItems)
                _orderItems.Add(OrderItem.Create(orderItem.ProductId,orderItem.Quantity,orderItem.OrderId));
        }

        private void EditOrderItems(List<CreateOrderItemDto> orderItems)
        {
            foreach (var orderItem in _orderItems)
            {
                var findOrderItem = orderItems.Find(i => i.Id == orderItem.Id);

                if (findOrderItem == null)
                    orderItem.ChangeStatus(EntityStateType.Deleted);
                else
                    orderItem.Edit(findOrderItem.ProductId, findOrderItem.Quantity);
            }

            foreach (var orderItem in orderItems.Where(t => t.Id == 0))
                _orderItems.Add(OrderItem.Create(orderItem.ProductId, orderItem.Quantity, orderItem.OrderId));
        }



        #endregion
    }
}
