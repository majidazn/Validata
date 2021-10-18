using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Common.Domain.SeedWork;

namespace Validata.Domain.CustomerAggregate.Entities
{
    public class Order : Entity
    {
        #region Constructor
        private Order(int customerId,DateTime orderDate, decimal totalPrice)
        {
            CustomerId= customerId;
            OrderDate = orderDate;
            TotalPrice = totalPrice;
        }   

        #endregion

        #region Properties
        public new int Id { get; private set; }
        public int CustomerId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public decimal TotalPrice { get; private set; }


        private readonly List<OrderItems> _orderItems = new List<OrderItems>();
        public IReadOnlyCollection<OrderItems> OrderItems => _orderItems.AsReadOnly();


        #endregion



        #region Behaviors

        #endregion
    }
}
