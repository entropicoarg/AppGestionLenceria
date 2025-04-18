using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductColor
    {
        public int ProductId { get; set; }
        public int ColorId { get; set; }

        // Navigation properties
        public virtual Product Product { get; set; }
        public virtual Color Color { get; set; }
    }
}
