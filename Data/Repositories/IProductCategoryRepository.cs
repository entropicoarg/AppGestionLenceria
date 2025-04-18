using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IProductCategoryRepository : IGenericRepository<ProductCategory>
    {
        Task<IEnumerable<ProductCategory>> GetByProductAsync(int productId);
        Task<IEnumerable<ProductCategory>> GetByCategoryAsync(int categoryId);
    }
}
