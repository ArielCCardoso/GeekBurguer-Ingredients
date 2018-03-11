using System.Collections.Generic;

namespace GeekBurger.Ingredients.Contracts
{

    /// <summary>
    /// Request for products with restriction
    /// </summary>
    public class ProductRestrictionRequest
    {
        /// <summary>
        /// List o restricition
        /// </summary>
        public IEnumerable<string> Restrictions { get; set; }
    }
}
