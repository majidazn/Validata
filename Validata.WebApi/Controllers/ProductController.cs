using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Validata.ApplicationServices.Product.Commands.CreateProductCommand;
using Validata.ApplicationServices.Product.Commands.EditProductCommand;
using Validata.ApplicationServices.Product.Commands.RemoveProductCommand;

namespace Validata.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        #region Fields

        private readonly IMediator _mediator;


        #endregion
        #region Constructor

        public ProductController(IMediator mediator
           )
        {
            _mediator = mediator;

        }

        #endregion

        #region Methods

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand createProductCommand, CancellationToken cancellationToken = default)
             => Ok(await _mediator.Send(createProductCommand, cancellationToken));

        [HttpPost]
        public async Task<IActionResult> EditProduct(EditProductCommand editProductCommand, CancellationToken cancellationToken = default)
             => Ok(await _mediator.Send(editProductCommand, cancellationToken));


        [HttpPost]
        public async Task<IActionResult> RemoveProduct(RemoveProductCommand removeProductCommand, CancellationToken cancellationToken = default)
              => Ok(await _mediator.Send(removeProductCommand, cancellationToken));


        #endregion
    }
}
