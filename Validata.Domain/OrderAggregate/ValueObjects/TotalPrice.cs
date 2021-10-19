using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Common.Domain.SeedWork;

namespace Validata.Domain.OrderAggregate.ValueObjects
{
    public class TotalPrice : ValueObject
    {
        #region Properties
        public decimal Value { get; private set; }
        #endregion

        #region Constructors
        private TotalPrice(decimal value)
        {
            this.Value = value;
        }
        #endregion


        #region Behaviors

        public static TotalPrice Create(decimal value)
        {

            if (value <= 0)
                throw new Exception("TotalPrice cannot be zero or less than zero!");


            return new TotalPrice(value);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }


        #endregion
    }

}
