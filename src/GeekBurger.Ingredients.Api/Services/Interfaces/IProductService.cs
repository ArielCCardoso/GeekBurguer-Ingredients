using GeekBurger.Ingredients.Api.Models;

namespace GeekBurger.Ingredients.Api.Services.Interfaces
{
    public interface IProductService
    {
        ProductContract GetProductByName(string name);
    }
}
