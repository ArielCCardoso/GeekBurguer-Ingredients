using GeekBurger.Ingredients.Api.Models;
using GeekBurger.Ingredients.Api.Services.Interfaces;
using RestSharp;

namespace GeekBurger.Ingredients.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly string _productUrl;

        public ProductService(Configuration configuration)
        {
            _productUrl = configuration.ProductResource;
        }

        public ProductContract GetProductByName(string name)
        {
            var client = new RestClient(_productUrl);

            var request = new RestRequest($"{name}", Method.GET);

            ProductContract product = null;

            client.ExecuteAsync<ProductContract>(request, response =>
            {
                product = response.Data;
            });

            return product;
        }
    }
}
