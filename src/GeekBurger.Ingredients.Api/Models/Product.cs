using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace GeekBurger.Ingredients.Api.Models
{
    public class Product
    {
        [BsonId]
        [BsonElement("_id")]
        public Guid ProductId { get; set; }

        [BsonElement("items")]
        public IEnumerable<Item> Items { get; set; }
    }
}
