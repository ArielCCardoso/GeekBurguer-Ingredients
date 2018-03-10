using System;

namespace GeekBurger.Ingredients.Api.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }
    }
}
