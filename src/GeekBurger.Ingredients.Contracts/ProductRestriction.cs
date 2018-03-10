using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBurger.Ingredients.Contracts
{
   public class ProductRestriction
    {
        public IEnumerable<string> Restrictions { get; set; }
    }
}
