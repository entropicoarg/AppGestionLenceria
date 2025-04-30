using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string PaymentMethodDetail { get; set; } // For when PaymentMethod is "Other"
        public string TicketNumber { get; set; }
        public string InvoiceNumber { get; set; }

        // Foreign key
        public int CustomerId { get; set; }

        // Navigation properties
        public virtual Customer Customer { get; set; }
        public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();

        public void CalculateTotalPrice()
        {
            TotalPrice = SaleDetails.Sum(s => s.Subtotal);
        }
    }
}
