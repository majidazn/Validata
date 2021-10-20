using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Common.Dtos.KendoGrid;

namespace Validata.Domain.CustomerAggregate.Dtos
{
   public  class SearcCustomerhDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public GridState gridState { get; set; }
    }
}
