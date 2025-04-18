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
    public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(LingerieDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProductCategory>> GetByProductAsync(int productId)
        {
            return await _context.ProductCategories
                .Include(pc => pc.Category)
                .Where(pc => pc.ProductId == productId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductCategory>> GetByCategoryAsync(int categoryId)
        {
            return await _context.ProductCategories
                .Include(pc => pc.Product)
                .Where(pc => pc.CategoryId == categoryId)
                .ToListAsync();
        }
    }

}
