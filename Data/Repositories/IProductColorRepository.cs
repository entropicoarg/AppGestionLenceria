using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IProductColorRepository : IGenericRepository<ProductColor>
    {
        Task<IEnumerable<ProductColor>> GetByProductAsync(int productId);
        Task<IEnumerable<ProductColor>> GetByColorAsync(int colorId);
    }
}
