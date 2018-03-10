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

        public IEnumerable<Product> GetIngredients(Guid productId)
        {
            var ingredients = new List<Ingredient>()
            {
                Ingredient.Create(productId, "Açucar"),
                Ingredient.Create(productId, "Leite"),
                Ingredient.Create(productId, "Farinha de Trigo"),
                Ingredient.Create(productId, "Sal"),
            };

            return _mapper.Map<IEnumerable<Product>>(ingredients);
        }

        public Product GetIngredient(Guid productId, Guid ingredientId)
        {
            var ingredient = Ingredient.Create(productId, "Açucar");

            return _mapper.Map<Product>(ingredient);
        }

        public Product Create(Guid productId, Product request)
        {
            var ingredient = Ingredient.Create(productId, request.Description);

            return _mapper.Map<Product>(ingredient);
        }

        public Product Update(Guid productId, Guid ingredientId, Product request)
        {
            var ingredient = Ingredient.Create(productId, request.Description);

            return _mapper.Map<Product>(ingredient);
        }
    }
}
