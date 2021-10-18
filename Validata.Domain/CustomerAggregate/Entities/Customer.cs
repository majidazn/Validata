using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validata.Domain.CustomerAggregate.Entities
{
    public class Customer
    {
        #region Constructor
        private Customer()
        {

        }
        #endregion

        #region Properties
        public new int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }

        #endregion



        #region Behaviors

        #endregion
    }
}
