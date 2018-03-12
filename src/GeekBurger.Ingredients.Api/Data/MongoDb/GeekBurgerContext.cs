using GeekBurger.Ingredients.Api.Models;
using MongoDB.Driver;

namespace GeekBurger.Ingredients.Api.Data.MongoDb
{
    public class GeekBurgerContext
    {
        private readonly IMongoDatabase Database;

        public GeekBurgerContext(Configuration configuration)
        {
            var client = new MongoClient(configuration.MongoDb.Connection);

            Database = client.GetDatabase(configuration.MongoDb.Database);
        }

        public IMongoCollection<ProductIngredient> ProductIngredients => Database.GetCollection<ProductIngredient>("ProductIngredient");
    }
}
