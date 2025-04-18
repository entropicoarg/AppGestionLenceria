using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetBySupplierAsync(int supplierId);
        Task<Product> GetWithAllRelationsAsync(int id);
        Task<IEnumerable<Color>> GetProductColorsAsync(int productId);
        Task<IEnumerable<Category>> GetProductCategoriesAsync(int productId);
        Task AddProductColorAsync(int productId, int colorId);
        Task AddProductCategoryAsync(int productId, int categoryId);
        Task RemoveProductColorAsync(int productId, int colorId);
        Task RemoveProductCategoryAsync(int productId, int categoryId);
    }
}
