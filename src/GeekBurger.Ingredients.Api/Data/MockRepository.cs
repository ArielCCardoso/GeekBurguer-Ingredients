using AutoMapper;
using GeekBurger.Ingredients.Api.Models;
using GeekBurger.Ingredients.Contracts;
using System;
using System.Collections.Generic;

namespace GeekBurger.Ingredients.Api.Data
{
    public class MockRepository
    {
        private readonly IMapper _mapper;

        public MockRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<IngredientResponse> GetIngredients(Guid productId)
        {
            var ingredients = new List<Ingredient>()
            {
                Ingredient.Create(productId, "Açucar"),
                Ingredient.Create(productId, "Leite"),
                Ingredient.Create(productId, "Farinha de Trigo"),
                Ingredient.Create(productId, "Sal"),
            };

            return _mapper.Map<IEnumerable<IngredientResponse>>(ingredients);
        }

        public IngredientResponse GetIngredient(Guid productId, Guid ingredientId)
        {
            var ingredient = Ingredient.Create(productId, "Açucar");

            return _mapper.Map<IngredientResponse>(ingredient);
        }

        public IngredientResponse Create(Guid productId, IngredientRequest request)
        {
            var ingredient = Ingredient.Create(productId, request.Description);

            return _mapper.Map<IngredientResponse>(ingredient);
        }

        public IngredientResponse Update(Guid productId, Guid ingredientId, IngredientRequest request)
        {
            var ingredient = Ingredient.Create(productId, request.Description);

            return _mapper.Map<IngredientResponse>(ingredient);
        }
    }
}
