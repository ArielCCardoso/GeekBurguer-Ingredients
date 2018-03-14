using GeekBurger.Ingredients.Api.Models;

namespace GeekBurger.Ingredients.Api.Data.Intefaces
{
    interface IProductApiRepository
    {
        ProductContract GetProductByName(string name);
    }
}
