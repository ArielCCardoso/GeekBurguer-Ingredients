using System.Collections.Generic;

namespace GeekBurger.Ingredients.Test.ServiceBus
{
    public class Label
    {
        public string ProductName { get; set; }

        public IEnumerable<string> Ingredients { get; set; }
    }
}
