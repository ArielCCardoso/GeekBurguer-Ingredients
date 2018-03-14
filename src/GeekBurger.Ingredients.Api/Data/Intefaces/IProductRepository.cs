using GeekBurger.Ingredients.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeekBurger.Ingredients.Api.Data.Intefaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts(IEnumerable<string> restrictions);

        Task Create(Product product);
    }
}
