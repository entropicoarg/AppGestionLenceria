using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface ISaleRepository : IGenericRepository<Sale>
    {
        Task<Sale> GetWithDetailsAsync(int id);
        Task<IEnumerable<Sale>> GetByCustomerAsync(int customerId);
        Task<IEnumerable<Sale>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
