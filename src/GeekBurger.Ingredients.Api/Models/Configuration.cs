namespace GeekBurger.Ingredients.Api.Models
{
    public class Configuration
    {
        public ServiceBus ServiceBus { get; set; }

        public string ProductResource { get; set; }
    }

    public class ServiceBus
    {
        public string ConnectionString { get; set; }

        public string Path { get; set; }
    }
}
