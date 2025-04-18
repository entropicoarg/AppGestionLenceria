using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public decimal DiscountAmount { get; set; }

        // Calculated property
        public decimal CalculatedPrice => Cost + DiscountAmount;
        public decimal RoundedPrice { get; set; }
        public string SKU { get; set; }
        public decimal Profitability { get; set; }
        public string OrderNumber { get; set; }

        // Foreign keys
        public int SupplierId { get; set; }
        public int SizeId { get; set; }

        // Navigation properties
        public virtual Supplier Supplier { get; set; }
        public virtual Size Size { get; set; }
        public virtual ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();
        public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
        public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
    }
}
