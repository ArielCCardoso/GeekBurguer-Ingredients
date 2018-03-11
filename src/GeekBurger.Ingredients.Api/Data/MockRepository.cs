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

        public IEnumerable<ProductResponse> GetProducts(string restrictions)
        {
            var products = new List<ProductIngredient>()
            {
               new ProductIngredient(Guid.NewGuid(), new List<string> { "meat burger", "smoked bacon", "picles" }),
               new ProductIngredient(Guid.NewGuid(), new List<string> { "meat burger", "smoked bacon", "picles" }),
               new ProductIngredient(Guid.NewGuid(), new List<string> { "onions", "mushrooms", "green peppers"}),
            };

            return _mapper.Map<IEnumerable<ProductResponse>>(products);
        }
    }
}
