using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validata.ApplicationServices.Order.Commands.RemoveOrderCommand
{
    public class RemoveOrderCommand : IRequest<bool>
    {
        #region Constructors
        public RemoveOrderCommand(int orderId)
        {
            OrderId = orderId;
        }
        #endregion

        #region Properties
        public int OrderId { get; set; }

        #endregion
    }
}
