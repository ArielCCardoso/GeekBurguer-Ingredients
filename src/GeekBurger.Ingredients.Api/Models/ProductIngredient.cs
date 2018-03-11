using System;
using System.Collections.Generic;

namespace GeekBurger.Ingredients.Api.Models
{
    public class ProductIngredient
    {
        public ProductIngredient(Guid id, IEnumerable<string> ingredients)
        {
            Id = id;
            Ingredients = ingredients;
        }

        public Guid Id { get; private set; }

        public IEnumerable<string> Ingredients { get; private set; }
    }
}
