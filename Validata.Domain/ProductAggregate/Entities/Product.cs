using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Common.Domain.SeedWork;
using Validata.Common.Enums;
using Validata.Domain.ProductAggregate.ValueObjects;

namespace Validata.Domain.ProductAggregate.Entities
{
    public class Product : Entity, IAggregateRoot
    {
        #region Constructor
        private Product(string name, decimal price)
        {
            Name = name;
            Price = Price.Create(price);

            Status = EntityStateType.Default;
        }
        #endregion

        #region Properties
        public new int Id { get; private set; }
        public string Name { get; private set; }

        public Price Price { get; private set; }
        public EntityStateType Status { get; private set; }

        #endregion



        #region Behaviors

        public static async Task<Product> Create(string name, decimal price)
        {
            EnforceInvariants(name);
            var product = new Product(name,price);


           
            
            return product;
        }

        public void EditProduct(string name, decimal price)
        {
            EnforceInvariants(name);
            Name = name;
            Price = Price.Create(price);

        }

        public void RemoveProduct()
        {


            Status = EntityStateType.Deleted;
        }

        private static void EnforceInvariants(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("FirstName is required!");

            if (name?.Length > 50)
                throw new Exception("Maximum length for name is 50 character!");
        }

        #endregion
    }
}
