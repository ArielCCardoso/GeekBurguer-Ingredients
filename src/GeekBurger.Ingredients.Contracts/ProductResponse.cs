﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBurger.Ingredients.Contracts
{
    public class ProductResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public IEnumerable<string> Ingredients { get; set; }
    }
}
