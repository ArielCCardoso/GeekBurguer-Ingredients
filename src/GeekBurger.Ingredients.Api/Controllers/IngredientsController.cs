using GeekBurger.Ingredients.Api.Data;
using GeekBurger.Ingredients.Api.Data.Intefaces;
using GeekBurger.Ingredients.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Get([FromQuery] string restrictions)
        {
            var ingredients = _mockRepository.GetProducts(restrictions);

            return Ok(ingredients);
        }
    }
}
