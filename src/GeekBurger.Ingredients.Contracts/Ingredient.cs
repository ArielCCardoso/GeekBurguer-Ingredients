using System;

namespace GeekBurger.Ingredients.Contracts
{
    public class Ingredient
    {
        public Guid IngredientId { get; }

        public Guid ProductId { get; set; }

        public string Description { get; set; }
    }
}
