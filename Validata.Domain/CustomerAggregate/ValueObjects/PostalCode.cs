using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Common.Domain.SeedWork;

namespace Validata.Domain.CustomerAggregate.ValueObjects
{
 
    public class PostalCode : ValueObject
    {
        #region Properties
        public string Value { get; private set; }
        #endregion

        #region Constructors
        private PostalCode(string value)
        {
            this.Value = value;
        }
        #endregion


        #region Behaviors

        public static PostalCode Create(string value)
        {

            if (value.Length ==6 )
                throw new Exception("Length of the Postal Code must be six character!");


            return new PostalCode(value);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }


        #endregion
    }

}
