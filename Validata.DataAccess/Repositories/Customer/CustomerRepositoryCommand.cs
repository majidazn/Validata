using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Common.Repository;
using Validata.DataAccess.Context;
using Validata.Domain.CustomerAggregate.Repositories;

namespace Validata.DataAccess.Repositories.Customer
{
   public class CustomerRepositoryCommand : Repository<Domain.CustomerAggregate.Entities.Customer>, ICustomerRepositoryCommand
    {
        private readonly ECommerceBoundedContextCommand _eCommerceBoundedContextCommand;
        public CustomerRepositoryCommand(ECommerceBoundedContextCommand dbContext, IHttpContextAccessor httpContextAccessor = null)
            : base(dbContext, httpContextAccessor)
        {
            _eCommerceBoundedContextCommand = dbContext;
        }
    }
}
