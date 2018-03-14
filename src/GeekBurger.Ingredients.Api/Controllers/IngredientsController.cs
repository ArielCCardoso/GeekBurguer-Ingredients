using AutoMapper;
using GeekBurger.Ingredients.Api.Data.Intefaces;
using GeekBurger.Ingredients.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeekBurger.Ingredients.Api.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public IngredientsController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet("ingredients/products")]
        public async Task<IActionResult> Get([FromQuery] string restrictions)
        {
            IEnumerable<string> listRestrictions = !string.IsNullOrEmpty(restrictions) ? restrictions.Split(",") : null;

            var products = await _productRepository.GetProducts(listRestrictions);

            var response = _mapper.Map<IEnumerable<ProductResponse>>(products);

            return Ok(response);
        }
    }
}
