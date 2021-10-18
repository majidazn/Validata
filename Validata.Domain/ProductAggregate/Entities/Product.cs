using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Common.Domain.SeedWork;

namespace Validata.Domain.ProductAggregate.Entities
{
  public  class Product:Entity
    {
        #region Constructor
        private Product()
        {

        }
        #endregion

        #region Properties
        public new int Id { get; private set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        #endregion



        #region Behaviors

        #endregion
    }
}
