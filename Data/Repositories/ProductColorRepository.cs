using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProductColorRepository : GenericRepository<ProductColor>, IProductColorRepository
    {
        public ProductColorRepository(LingerieDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProductColor>> GetByProductAsync(int productId)
        {
            return await _context.ProductColors
                .Include(pc => pc.Color)
                .Where(pc => pc.ProductId == productId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductColor>> GetByColorAsync(int colorId)
        {
            return await _context.ProductColors
                .Include(pc => pc.Product)
                .Where(pc => pc.ColorId == colorId)
                .ToListAsync();
        }
    }
}
