using System;

namespace GeekBurger.Ingredients.Contracts
{
    public class Ingredient
    {
        private Ingredient(Guid productId, string description)
        {
            ProductId = productId;
            Description = description;
            IngredientId = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        public Guid IngredientId { get; private set; }

        public Guid ProductId { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; private set; }

        public static Ingredient Create(Guid productId, string description)
        {
            return new Ingredient(productId, description);
        }
    }
}
