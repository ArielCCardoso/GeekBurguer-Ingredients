using GeekBurger.Ingredients.Contracts;
using System;
using System.Collections.Generic;

namespace GeekBurger.Ingredients.Api.Data
{
    public class MockRepository
    {
        public IEnumerable<Ingredient> GetIngredients(Guid productId)
        {
            return new List<Ingredient>()
            {
                Ingredient.Create(productId, "Açucar"),
                Ingredient.Create(productId, "Leite"),
                Ingredient.Create(productId, "Farinha de Trigo"),
                Ingredient.Create(productId, "Sal"),
            };
        }
    }
}
