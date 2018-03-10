using GeekBurger.Ingredients.Api.Models;

namespace GeekBurger.Ingredients.Api.Data.Intefaces
{
    interface IProductRepository
    {
        Product GetProductByName(string name);
    }
}
