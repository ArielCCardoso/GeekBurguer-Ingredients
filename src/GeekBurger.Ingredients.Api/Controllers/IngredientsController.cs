using GeekBurger.Ingredients.Api.Data;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GeekBurger.Ingredients.Api.Controllers
{
    [Route("ingredients")]
    public class IngredientsController : Controller
    {
        private readonly MockRepository _mockRepository;

        public IngredientsController(MockRepository mockRepository)
        {
            _mockRepository = mockRepository;
        }

        [HttpGet("{productId}")]
        public IActionResult Get(Guid productId)
        {
            var ingredients =_mockRepository.GetIngredients(productId);

            return Ok(ingredients);
        }
    }
}
