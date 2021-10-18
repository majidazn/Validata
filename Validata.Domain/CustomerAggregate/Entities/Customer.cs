using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Common.Domain.SeedWork;

namespace Validata.Domain.CustomerAggregate.Entities
{
    public class Customer: Entity, IAggregateRoot
    {
        #region Constructor
        private Customer(string firstName, string lastName, string address, string postalCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PostalCode = postalCode;
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
