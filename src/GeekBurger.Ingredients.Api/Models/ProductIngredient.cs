using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace GeekBurger.Ingredients.Api.Models
{
    [BsonDiscriminator("productIngredients")]
    public class ProductIngredient
    {
        [BsonConstructor]
        public ProductIngredient(Guid id, IEnumerable<string> ingredients)
        {
            Id = id;
            Ingredients = ingredients;
        }

        [BsonId]
        [BsonElement("_id")]
        public Guid Id { get; private set; }

        [BsonElement("ingredients")]
        public IEnumerable<string> Ingredients { get; private set; }
    }
}
