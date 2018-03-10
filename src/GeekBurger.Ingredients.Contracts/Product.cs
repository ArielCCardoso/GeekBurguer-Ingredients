using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBurger.Ingredients.Contracts
{
   /// <summary>
   /// Classe com as informações do produto
   /// </summary>
   public  class Product
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ProductType { get; set; }
    }
}
