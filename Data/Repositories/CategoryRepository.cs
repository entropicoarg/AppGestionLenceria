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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(LingerieDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _context.ProductCategories
                .Where(pc => pc.CategoryId == categoryId)
                .Select(pc => pc.Product)
                .ToListAsync();
        }

        public async Task<Category> GetWithProductsAsync(int categoryId)
        {
            return await _context.Categories
                .Include(c => c.ProductCategories)
                .ThenInclude(pc => pc.Product)
                .FirstOrDefaultAsync(c => c.Id == categoryId);
        }
    }
}
