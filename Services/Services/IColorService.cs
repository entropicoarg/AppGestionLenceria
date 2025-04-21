using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IColorService
    {
        Task<IEnumerable<Color>> GetAllAsync();
        Task<Color> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsByColorAsync(int colorId);
        Task<Color> CreateAsync(Color color);
        Task UpdateAsync(Color color);
        Task DeleteAsync(int id);
        Task AddProductColorAsync(int productId, int colorId);
        Task RemoveProductColorAsync(int productId, int colorId);
    }
}
