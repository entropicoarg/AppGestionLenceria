﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductCategory
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        // Navigation properties
        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
