using System;
using System.Collections.Generic;

namespace GeekBurger.Ingredients.Api.Models
{
    public class Item
    {
        public Guid Id { get; private set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public IEnumerable<Ingredient> Ingredients { get; private set; }
    }
}
