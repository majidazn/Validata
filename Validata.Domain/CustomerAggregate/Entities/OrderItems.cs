using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Common.Domain.SeedWork;

namespace Validata.Domain.CustomerAggregate.Entities
{
    public class OrderItems: Entity
    {
        #region Constructor
        private OrderItems()
        {

        }
        #endregion

        #region Properties
        public new int Id { get; private set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        #endregion



        #region Behaviors

        #endregion
    }
}
