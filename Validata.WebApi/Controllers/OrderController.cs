using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Validata.ApplicationServices.Order.Commands.CreateOrderCommand;
using Validata.ApplicationServices.Order.Commands.EditOrderCommand;
using Validata.ApplicationServices.Order.Commands.RemoveOrderCommand;

namespace Validata.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController :  ControllerBase
    {

        #region Fields

        private readonly IMediator _mediator;


        #endregion
        #region Constructor

        public OrderController(IMediator mediator
           )
        {
            _mediator = mediator;

        }

        #endregion

        #region Methods

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand createOrderCommand, CancellationToken cancellationToken = default)
             => Ok(await _mediator.Send(createOrderCommand, cancellationToken));


        [HttpPost]
        public async Task<IActionResult> EditOrder(EditOrderCommand editOrderCommand, CancellationToken cancellationToken = default)
             => Ok(await _mediator.Send(editOrderCommand, cancellationToken));

        [HttpPost]
        public async Task<IActionResult> RemoveOrder(RemoveOrderCommand removeOrderCommand, CancellationToken cancellationToken = default)
             => Ok(await _mediator.Send(removeOrderCommand, cancellationToken));


        #endregion
    }
}
