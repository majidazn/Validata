using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Common.Domain.SeedWork;

namespace Validata.Domain.ProductAggregate.ValueObjects
{
    public class Price : ValueObject
    {
        #region Properties
        public decimal Value { get; private set; }
        #endregion

        #region Constructors
        private Price(decimal value)
        {
            this.Value = value;
        }
        #endregion


        #region Behaviors

        public static Price Create(decimal value)
        {

            if (value <= 0)
                throw new Exception("Price cannot be zero or less than zero!");
           

            return new Price(value);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }


        #endregion
    }
}
