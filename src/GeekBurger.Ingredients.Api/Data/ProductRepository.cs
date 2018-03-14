using GeekBurger.Ingredients.Api.Data.Context;
using GeekBurger.Ingredients.Api.Data.Intefaces;
using GeekBurger.Ingredients.Api.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Ingredients.Api.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly GeekBurgerContext _context;

        public ProductRepository(GeekBurgerContext context)
        {
            _context = context;
        }

        public async Task Create(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task Update(Product product)
        {
            await _context.Products.ReplaceOneAsync(p => p.Id == product.Id, product);
        }

        public async Task<IEnumerable<Product>> GetProducts(IEnumerable<string> restrictions)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Empty;

            if (restrictions != null && restrictions.Any())
            {
                filter = Builders<Product>.Filter.In("product.items.ingredients", restrictions);
            }

            var result = await _context.Products.FindAsync(filter);

            return await result.ToListAsync();
        }
    }
}
