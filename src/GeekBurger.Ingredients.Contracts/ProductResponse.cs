using System;
using System.Collections.Generic;

namespace GeekBurger.Ingredients.Contracts
{
    /// <summary>
    /// Exposes product information and its of ingredients
    /// </summary>
    public class ProductResponse
    {
        /// <summary>
        /// Product Identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// List of Ingredients
        /// </summary>
        public IEnumerable<string> Ingredients { get; set; }
    }
}
