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

        public async Task AddProductCategoryAsync(int productId, int categoryId)
        {
            var productCategory = new ProductCategory
            {
                ProductId = productId,
                CategoryId = categoryId
            };

            await _context.ProductCategories.AddAsync(productCategory);
        }

        public async Task RemoveProductCategoryAsync(int productId, int categoryId)
        {
            var productCategory = await _context.ProductCategories
                .FirstOrDefaultAsync(pc => pc.ProductId == productId && pc.CategoryId == categoryId);

            if (productCategory != null)
            {
                _context.ProductCategories.Remove(productCategory);
            }
        }


    }
}
