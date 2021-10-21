using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Validata.ApplicationServices.Customer.Commands.CreateCustomerCommand;
using Validata.ApplicationServices.Customer.Commands.EditCustomerCommand;
using Validata.ApplicationServices.Customer.Commands.RemoveCustomerCommand;
using Validata.ApplicationServices.Customer.Queries;
using Validata.Common.Dtos;
using Validata.Domain.CustomerAggregate.Dtos;

namespace Validata.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {

        #region Fields

        private readonly IMediator _mediator;


        #endregion
        #region Constructor

        public CustomerController(IMediator mediator
           )
        {
            _mediator = mediator;

        }

        #endregion


        #region Methods

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerCommand createCustomerCommand, CancellationToken cancellationToken = default)
             => Ok(await _mediator.Send(createCustomerCommand, cancellationToken));


        [HttpPost]
        public async Task<IActionResult> EditCustomer(EditCustomerCommand editCustomerCommand, CancellationToken cancellationToken = default)
            => Ok(await _mediator.Send(editCustomerCommand, cancellationToken));


        [HttpPost]
        public async Task<IActionResult> RemoveCustomer(RemoveCustomerCommand removeCustomerCommand, CancellationToken cancellationToken = default)
            => Ok(await _mediator.Send(removeCustomerCommand, cancellationToken));



        [HttpPost]
        public async Task<ActionResult<GridResultDto<CustomerResultSearchDto>>> SearchCustomer(SearcCustomerhDto dto)
            => Ok(await _mediator.Send(new CustomerSearchQuery() { SearchDto = dto }));

        #endregion
    }
}
