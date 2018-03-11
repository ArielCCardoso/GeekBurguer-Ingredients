using AutoMapper;
using GeekBurger.Ingredients.Api.Models;
using GeekBurger.Ingredients.Contracts;

namespace GeekBurger.Ingredients.Api.AutoMapper
{
    public class ApplicationProfile: Profile
    {
        public ApplicationProfile()
        {
            CreateMap<ProductIngredient, ProductResponse>();
        }
    }
}
