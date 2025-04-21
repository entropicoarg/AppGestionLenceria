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
    public class ColorRepository : GenericRepository<Color>, IColorRepository
    {
        public ColorRepository(LingerieDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsByColorAsync(int colorId)
        {
            return await _context.ProductColors
                .Where(pc => pc.ColorId == colorId)
                .Select(pc => pc.Product)
                .ToListAsync();
        }

        public async Task<Color> GetWithProductsAsync(int colorId)
        {
            return await _context.Colors
                .Include(c => c.ProductColors)
                .ThenInclude(pc => pc.Product)
                .FirstOrDefaultAsync(c => c.Id == colorId);
        }

        public async Task AddProductColorAsync(int productId, int colorId)
        {
            var productColor = new ProductColor
            {
                ProductId = productId,
                ColorId = colorId
            };

            await _context.ProductColors.AddAsync(productColor);
        }

        public async Task RemoveProductColorAsync(int productId, int colorId)
        {
            var productColor = await _context.ProductColors
                .FirstOrDefaultAsync(pc => pc.ProductId == productId && pc.ColorId == colorId);

            if (productColor != null)
            {
                _context.ProductColors.Remove(productColor);
            }
        }
    }
}
