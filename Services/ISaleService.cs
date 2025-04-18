using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ISaleService
    {
        Task<IEnumerable<Sale>> GetAllAsync();
        Task<Sale> GetByIdAsync(int id);
        Task<Sale> GetWithDetailsAsync(int id);
        Task<IEnumerable<Sale>> GetByCustomerAsync(int customerId);
        Task<IEnumerable<Sale>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<Sale> CreateAsync(Sale sale, IEnumerable<SaleDetail> details);
        Task UpdateAsync(Sale sale);
        Task DeleteAsync(int id);
    }
}
