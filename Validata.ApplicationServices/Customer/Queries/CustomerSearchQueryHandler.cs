using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Validata.Common.Dtos;
using Validata.Common.Dtos.KendoGrid;
using Validata.Domain.CustomerAggregate.Dtos;
using Validata.Domain.CustomerAggregate.Repositories;

namespace Validata.ApplicationServices.Customer.Queries
{
    public class CustomerSearchQueryHandler : IRequestHandler<CustomerSearchQuery, GridResultDto<CustomerResultSearchDto>>
    {
        private readonly ICustomerRepositoryQuery _customerRepositoryQuery;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerSearchQueryHandler(ICustomerRepositoryQuery customerRepositoryQuery,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _customerRepositoryQuery = customerRepositoryQuery;
            _httpContextAccessor = httpContextAccessor;

        }
        public async Task<GridResultDto<CustomerResultSearchDto>> Handle(CustomerSearchQuery request, CancellationToken cancellationToken)
        {
            var model = request.SearchDto;
            var customers = _customerRepositoryQuery.GetCustomers();

            if (!string.IsNullOrEmpty(model.FirstName))
                customers = customers.Where(it => it.FirstName.Contains(model.FirstName));

            if (!string.IsNullOrEmpty(model.LastName))
                customers = customers.Where(it => it.LastName.Contains(model.LastName));

            if (!string.IsNullOrEmpty(model.Address))
                customers = customers.Where(it => it.Address.Contains(model.Address));

            if (!string.IsNullOrEmpty(model.PostalCode))
                customers = customers.Where(it => it.PostalCode.Value.Contains(model.PostalCode));


            var count = await customers.CountAsync();
            var result = await customers.ApplyPagingAsync(model.gridState, count);


            var lstCustomerSearchDto = new List<CustomerResultSearchDto>();

            foreach (var customer in result.data)
            {
                lstCustomerSearchDto.Add(new CustomerResultSearchDto
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address = customer.Address,
                    PostalCode = customer.PostalCode.Value
                });
            }
            var gridModel = new GridResultDto<CustomerResultSearchDto>()
            {
                data = lstCustomerSearchDto,
                GridState = model.gridState,
                total = result.total,
            };

            return gridModel;
        }
    }
}

