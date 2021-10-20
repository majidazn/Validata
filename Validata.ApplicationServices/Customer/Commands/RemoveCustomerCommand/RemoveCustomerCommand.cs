using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validata.ApplicationServices.Customer.Commands.RemoveCustomerCommand
{
    public class RemoveCustomerCommand : IRequest<bool>
    {
        #region Constructors
        public RemoveCustomerCommand(int customerId)
        {
            CustomerId = customerId;
        }
        #endregion

        #region Properties
        public int CustomerId { get; set; }

        #endregion
    }
}
