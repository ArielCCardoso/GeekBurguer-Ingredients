using AutoMapper;
using GeekBurger.Ingredients.Api.Data.Intefaces;
using GeekBurger.Ingredients.Api.Models;
using GeekBurger.Ingredients.Api.Services.Interfaces;
using GeekBurger.Products.Contract;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Ingredients.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly string _productUrl;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper, Configuration configuration)
        {
            _productUrl = configuration.ProductResource;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task Save(Label label)
        {
            IEnumerable<ProductToGet> productsToGet = GetProductByName(label.ItemName);

            if (productsToGet == null) return;

            IEnumerable<Product> products = _mapper.Map<IEnumerable<Product>>(productsToGet);

            foreach (var p in products)
            {
                p.ChangeIngredients(label.ItemName, label.Ingredients);

                await _productRepository.Save(p);
            }
        }

        public IEnumerable<ProductToGet> GetProductByName(string itemName)
        {
            List<ProductToGet> products = GetProductsFromResource();

            if (products == null)
                return null;

            return products.Where(p => p.Items.Any(i => i.Name.ToLower() == itemName.ToLower()));
        }

        private List<ProductToGet> GetProductsFromResource()
        {
            var client = new RestClient(_productUrl);

            var request = new RestRequest(Method.GET);

            List<ProductToGet> products = null;

            client.ExecuteAsync<List<ProductToGet>>(request, response =>
            {
                products = response.Data;
            });

            return products;
        }
    }
}
