using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Common.Domain.SeedWork;
using Validata.Common.Enums;

namespace Validata.Domain.OrderAggregate.Entities
{
    public class OrderItem : Entity
    {
        #region Constructor
        public OrderItem()
        {

        }
        private OrderItem(int productId, int quantity, int orderId)
        {
            ProductId = productId;
            Quantity = quantity;
            OrderId = orderId;
            Status = EntityStateType.Default;
        }
        #endregion

        #region Properties
        public new int Id { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public int OrderId { get; private set; }

        public EntityStateType Status { get; private set; }

        #endregion



        #region Behaviors
        public static OrderItem Create(int productId, int quantity, int orderId)
        {
            EnforceInvariantsCreate(productId, quantity, orderId);
            return new OrderItem(productId, quantity, orderId);
        }
        public void Edit(int productId, int quantity)
        {
            EnforceInvariantsEdit(productId, quantity);

            ProductId = productId;
            Quantity = quantity;


        }
        public void ChangeStatus(EntityStateType status) => this.Status = status;
        private static void EnforceInvariantsCreate(int productId, int quantity, int orderId)
        {
            if (productId <= 0)
                throw new Exception("ProductId is required!");

            if (quantity <= 0)
                throw new Exception("Quantity is required!");

            if (orderId <= 0)
                throw new Exception("OrderId is required!");
        }
        private static void EnforceInvariantsEdit(int productId, int quantity)
        {
            if (productId <= 0)
                throw new Exception("ProductId is required!");

            if (quantity <= 0)
                throw new Exception("Quantity is required!");

        }
        #endregion
    }
}
