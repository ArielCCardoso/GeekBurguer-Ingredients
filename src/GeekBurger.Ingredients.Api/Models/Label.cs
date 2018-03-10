using System.Collections.Generic;

namespace GeekBurger.Ingredients.Api.Models
{
    public class Label
    {
        public string ProductName { get; set; }

        public IEnumerable<string> Ingredients { get; set; }
    }
}
