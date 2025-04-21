using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IColorRepository : IGenericRepository<Color>
    {
        Task<IEnumerable<Product>> GetProductsByColorAsync(int colorId);
        Task<Color> GetWithProductsAsync(int colorId);
        Task AddProductColorAsync(int productId, int colorId);
        Task RemoveProductColorAsync(int productId, int colorId);

    }
}
