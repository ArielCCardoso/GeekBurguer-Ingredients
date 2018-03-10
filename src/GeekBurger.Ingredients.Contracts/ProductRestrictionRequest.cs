using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBurger.Ingredients.Contracts
{
    
    /// <summary>
    /// Classe representa resposta do produto onde será encaminhado
    /// Esta classe retorna uma lista com as restrições do produto
    /// </summary>
   public class ProductRestrictionRequest
    {
        public IEnumerable<string> Restrictions { get; set; }
    }
}
