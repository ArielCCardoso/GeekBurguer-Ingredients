using System;

namespace GeekBurger.Ingredients.Contracts
{
    public class IngredientResponse
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
