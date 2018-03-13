using GeekBurger.Ingredients.Api.Data.Context;
using GeekBurger.Ingredients.Api.Data.Intefaces;
using GeekBurger.Ingredients.Api.Models;
using Microsoft.EntityFrameworkCore;
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
            _context.Products.Add(product);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts(IEnumerable<string> restrictions)
        {
            //return await _context.Products
            //    .Where(p => !p.Items.Any(i => i.Ingredients.Any(g => restrictions.Contains(g.Description))))
            //    .ToListAsync();


            var products = from p in _context.Products
                           join i in _context.Items
                           on p.Id equals i.ProductId
                           join g in _context.Ingredients
                           on i.Id equals g.ItemId
                           where restrictions.Contains(g.Description)
                           select p;

            return products;
            
        }
    }
}
