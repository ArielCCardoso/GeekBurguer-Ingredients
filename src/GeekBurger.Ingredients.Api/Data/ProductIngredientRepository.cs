using GeekBurger.Ingredients.Api.Data.Intefaces;
using GeekBurger.Ingredients.Api.Data.MongoDb;
using GeekBurger.Ingredients.Api.Models;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace GeekBurger.Ingredients.Api.Data
{
    public class ProductIngredientRepository : IProductIngredientRepository
    {
        private readonly GeekBurgerContext _context;

        public ProductIngredientRepository(GeekBurgerContext context)
        {
            _context = context;
        }

        public async Task Save(ProductIngredient productIngredient)
        {
            await _context.ProductIngredients
                .InsertOneAsync(productIngredient);
        }

        public async Task Update(ProductIngredient productIngredient)
        {
            await _context.ProductIngredients
                .ReplaceOneAsync(pi => pi.Id == productIngredient.Id, productIngredient);
        }
    }
}
