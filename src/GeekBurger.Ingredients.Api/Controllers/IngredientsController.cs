using GeekBurger.Ingredients.Api.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GeekBurger.Ingredients.Api.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly MockRepository _mockRepository;

        public IngredientsController(MockRepository mockRepository)
        {
            _mockRepository = mockRepository;
        }

        [HttpGet("ingredients/products")]
        public IActionResult Get([FromQuery] string restrictions)
        {
            var ingredients = _mockRepository.GetProducts(restrictions);

            return Ok(ingredients);
        }
    }
}
