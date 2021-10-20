using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Validata.ApplicationServices.Infrastrutures.UnitOfWork;
using Validata.Domain.ProductAggregate.Repositories;

namespace Validata.ApplicationServices.Product.Commands.EditProductCommand
{
    public class EditProductCommandHandler : IRequestHandler<EditProductCommand, bool>
    {
        #region Fields

        private readonly IProductRepositoryCommand _productRepositoryCommand;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors
        public EditProductCommandHandler(IProductRepositoryCommand productRepositoryCommand, IUnitOfWork unitOfWork)
        {
            _productRepositoryCommand = productRepositoryCommand;
            _unitOfWork = unitOfWork;
        }
        #endregion


        public async Task<bool> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepositoryCommand.FetchProductAggregate(request.EditProductDto.Id, cancellationToken);

            product.EditProduct(
                request.EditProductDto.Name,
                request.EditProductDto.Price
                );

            return (await _unitOfWork.CompleteAsync()) > 0;
        }

    }
}
