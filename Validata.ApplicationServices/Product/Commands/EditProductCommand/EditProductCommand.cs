using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Domain.ProductAggregate.Dtos;

namespace Validata.ApplicationServices.Product.Commands.EditProductCommand
{
    public class EditProductCommand : IRequest<bool>
    {
        #region Constructors
        public EditProductCommand(CreateProductDto editProductDto)
        {
            EditProductDto = editProductDto;
        }
        #endregion

        #region Properties
        public CreateProductDto EditProductDto { get; private set; }
        #endregion
    }
}
