using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Common.Dtos;
using Validata.Domain.CustomerAggregate.Dtos;

namespace Validata.ApplicationServices.Customer.Queries
{
    public class CustomerSearchQuery : IRequest<GridResultDto<CustomerResultSearchDto>>
    {
        public SearcCustomerhDto SearchDto { get; set; }
    }
}
