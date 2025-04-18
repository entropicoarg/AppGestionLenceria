using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation properties
        public virtual ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();
    }
}
