using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validata.ApplicationServices.Product.Commands.RemoveProductCommand
{
    public class RemoveProductCommand : IRequest<bool>
    {
        #region Constructors
        public RemoveProductCommand(int productId)
        {
            ProductId = productId;
        }
        #endregion

        #region Properties
        public int ProductId { get; set; }

        #endregion
    }
}
