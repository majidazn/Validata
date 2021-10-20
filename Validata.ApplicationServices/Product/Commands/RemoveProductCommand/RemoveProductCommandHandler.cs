using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Validata.ApplicationServices.Infrastrutures.UnitOfWork;
using Validata.Domain.ProductAggregate.Repositories;

namespace Validata.ApplicationServices.Product.Commands.RemoveProductCommand
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, bool>
    {
        #region Fields

        private readonly IProductRepositoryCommand _productRepositoryCommand;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors
        public RemoveProductCommandHandler(IProductRepositoryCommand productRepositoryCommand, IUnitOfWork unitOfWork)
        {
            _productRepositoryCommand = productRepositoryCommand;
            _unitOfWork = unitOfWork;
        }


        #endregion

        public async Task<bool> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepositoryCommand.GetProductById(request.ProductId, cancellationToken);
            product.RemoveProduct();

            return (await _unitOfWork.CompleteAsync()) > 0;

        }
    }
}
