using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SaleDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal => Quantity * UnitPrice;

        // Foreign keys
        public int SaleId { get; set; }
        public int ProductId { get; set; }

        // Navigation properties
        public virtual Sale Sale { get; set; }
        public virtual Product Product { get; set; }
    }
}
