using GeekBurger.Ingredients.Api.Models;
using System.Threading.Tasks;

namespace GeekBurger.Ingredients.Api.Services.Interfaces
{
    public interface IProductService
    {
        Task Save(Label label);
    }
}
