using GeekBurger.Ingredients.Api.Data.Intefaces;
using GeekBurger.Ingredients.Api.Models;
using RestSharp;

namespace GeekBurger.Ingredients.Api.Data
{
    public class ProductApiRepository : IProductApiRepository
    {
        private readonly string _productUrl;

        public ProductApiRepository(Configuration configuration)
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
