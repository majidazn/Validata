using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Validata.ApplicationServices.Customer.Commands.CreateCustomerCommand;

namespace Validata.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        #endregion
    }
}
