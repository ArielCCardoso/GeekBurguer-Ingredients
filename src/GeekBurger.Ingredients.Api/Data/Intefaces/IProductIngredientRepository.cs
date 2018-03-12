using GeekBurger.Ingredients.Api.Models;
using System.Threading.Tasks;

namespace GeekBurger.Ingredients.Api.Data.Intefaces
{
    public interface IProductIngredientRepository
    {
        Task Save(ProductIngredient productIngredient);
    }
}
