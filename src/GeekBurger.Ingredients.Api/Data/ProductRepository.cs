using GeekBurger.Ingredients.Api.Data.Intefaces;
using GeekBurger.Ingredients.Api.Models;
using RestSharp;

namespace GeekBurger.Ingredients.Api.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _productUrl;

        public ProductRepository(Configuration configuration)
        {
            _productUrl = configuration.ProductResource;
        }

        public Product GetProductByName(string name)
        {
            var client = new RestClient(_productUrl);

            var request = new RestRequest($"{name}", Method.GET);

            Product product = null;

            client.ExecuteAsync<Product>(request, response =>
            {
                product = response.Data;
            });

            return product;
        }
    }
}
