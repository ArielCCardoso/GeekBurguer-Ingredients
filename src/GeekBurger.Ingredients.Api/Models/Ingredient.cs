using System;

namespace GeekBurger.Ingredients.Api.Models
{
    public class Ingredient
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid ItemId { get; set; }

        public Item Item { get; set; }
    }
}
