using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Common.Domain.SeedWork;
using Validata.Common.Enums;
using Validata.Domain.CustomerAggregate.ValueObjects;
using Validata.Domain.OrderAggregate.Entities;

namespace Validata.Domain.CustomerAggregate.Entities
{
    public class Customer: Entity, IAggregateRoot
    {
        #region Constructor

        public Customer()
        {

        }

        private Customer(string firstName, string lastName, string address, string postalCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PostalCode = PostalCode.Create(postalCode);
            Status = EntityStateType.Default;
        }
        #endregion

        #region Properties
        public new int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public  PostalCode PostalCode { get; private set; }

        public EntityStateType Status { get; private set; }

        #endregion

        private readonly List<Order> _orders = new List<Order>();
        public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();

        #region Behaviors


        public static async Task<Customer> Create(string firstName, string lastName, string address, string postalCode)
        {
            var customer = new Customer(firstName, lastName, address, postalCode);

            EnforceInvariants(firstName, lastName, address);

            return customer;
        }

        public void EditCustomer(string firstName, string lastName, string address, string postalCode)
        {
            EnforceInvariants(firstName, lastName, address);


            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PostalCode = PostalCode.Create(postalCode);
        }

        public void RemoveCustomer()
        {
           

            Status = EntityStateType.Deleted;
        }




        private static void EnforceInvariants(string firstName, string lastName, string address)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new Exception("FirstName is required!");

            if (firstName?.Length > 50)
                throw new Exception("Maximum length for firstName is 50 character!");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new Exception("LastName is required!");

            if (lastName?.Length > 50)
                throw new Exception("Maximum length for lastName is 50 character!");

            if (string.IsNullOrWhiteSpace(address))
                throw new Exception("Address is required!");

            if (address?.Length > 200)
                throw new Exception("Maximum length for address is 200 character!");
        }

        #endregion
    }
}
