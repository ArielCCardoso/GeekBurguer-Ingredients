using GeekBurger.Ingredients.Api.Data.Context;
using GeekBurger.Ingredients.Api.Data.Intefaces;
using GeekBurger.Ingredients.Api.Models;
using System;
using System.Collections.Generic;
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
            _context.Products.Add(product);

            await _context.SaveChangesAsync();
        }

        public Task GetProducts(IEnumerable<string> restrictions)
        {
            throw new NotImplementedException();
        }
    }
}
