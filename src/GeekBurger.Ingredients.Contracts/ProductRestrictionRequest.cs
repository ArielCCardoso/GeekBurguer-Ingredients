using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBurger.Ingredients.Contracts
{
   public class ProductRestrictionRequest
    {
        public IEnumerable<string> Restrictions { get; set; }
    }
}
