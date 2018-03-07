using System;

namespace GeekBurger.Ingredients.Api.Models
{
    public class Ingredient
    {
        private Ingredient(Guid productId, string description)
        {
            ProductId = productId;
            Description = description;
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        // Is a temporary constructor
        private Ingredient(Guid productId, string description, Guid ingredientId)
        {
            Id = ingredientId;
            ProductId = productId;
            Description = description;
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; private set; }

        public Guid ProductId { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; private set; }

        public static Ingredient Create(Guid productId, string description)
        {
            return new Ingredient(productId, description);
        }

        // Temporary method
        public static Ingredient Create(Guid productId, string description, Guid ingredientId)
        {
            return new Ingredient(productId, description, ingredientId);
        }
    }
}
