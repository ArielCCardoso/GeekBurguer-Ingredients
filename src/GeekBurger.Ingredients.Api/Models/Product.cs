using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekBurger.Ingredients.Api.Models
{
    public class Product
    {
        [BsonId]
        [BsonElement("_id")]
        public Guid ProductId { get; set; }

        [BsonElement("items")]
        public IEnumerable<Item> Items { get; set; }

        public void ChangeIngredients(string itemName, IEnumerable<string> ingredients)
        {
            var item = Items.FirstOrDefault(i => i.Name.ToLower() == itemName.ToLower());
            item.Ingredients = ingredients;
        }
    }
}
