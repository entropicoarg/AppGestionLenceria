using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface ISaleDetailRepository : IGenericRepository<SaleDetail>
    {
        Task<IEnumerable<SaleDetail>> GetBySaleAsync(int saleId);
        Task<IEnumerable<SaleDetail>> GetByProductAsync(int productId);
    }
}
