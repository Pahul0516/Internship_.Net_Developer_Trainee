using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Validation
{
    class QuantityValidationStrategy : IValidationStrategy
    {
        public bool Validate(string input)
        {
            int quantity = int.Parse(input);
            if (quantity <= 0)
            {
                throw new ValidationException("The value has to be positive and not null!");
            }
            return true;
        }
    }
}
