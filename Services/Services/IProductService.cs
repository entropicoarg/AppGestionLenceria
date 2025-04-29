using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> GetAllWithRelationsAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> GetWithAllRelationsAsync(int id);
        Task<IEnumerable<Product>> GetBySupplierAsync(int supplierId);
        Task<IEnumerable<Color>> GetProductColorsAsync(int productId);
        Task<IEnumerable<Category>> GetProductCategoriesAsync(int productId);
        Task<Product> CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
