using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Domain.ProductAggregate.Dtos;

namespace Validata.ApplicationServices.Product.Commands.CreateProductCommand
{
    public class CreateProductCommand : IRequest<long>
    {
        #region Constructors
        public CreateProductCommand(CreateProductDto createProductDto)
        {
            CreateProductDto = createProductDto;
        }

        #endregion

        #region Properties

        public CreateProductDto CreateProductDto { get; private set; }

        #endregion
    }
}
