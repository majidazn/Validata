using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Validata.ApplicationServices.Infrastrutures.UnitOfWork;
using Validata.Domain.ProductAggregate.Repositories;

namespace Validata.ApplicationServices.Product.Commands.CreateProductCommand
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, long>
    {
        #region Fields

        private readonly IProductRepositoryCommand _productRepositoryCommand;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors
        public CreateProductCommandHandler(IProductRepositoryCommand productRepositoryCommand, IUnitOfWork unitOfWork)
        {
            _productRepositoryCommand = productRepositoryCommand;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await Domain.ProductAggregate.Entities.Product.Create(
                request.CreateProductDto.Name,
                request.CreateProductDto.Price
                );
            await _productRepositoryCommand.CreateAsync(product, cancellationToken);
            await _unitOfWork.CompleteAsync();
            return product.Id;
        }
    }
}
