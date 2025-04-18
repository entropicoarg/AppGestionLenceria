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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(LingerieDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetBySupplierAsync(int supplierId)
        {
            return await _context.Products
                .Where(p => p.SupplierId == supplierId)
                .ToListAsync();
        }

        public async Task<Product> GetWithAllRelationsAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Supplier)
                .Include(p => p.Size)
                .Include(p => p.ProductColors)
                    .ThenInclude(pc => pc.Color)
                .Include(p => p.ProductCategories)
                    .ThenInclude(pc => pc.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Color>> GetProductColorsAsync(int productId)
        {
            return await _context.ProductColors
                .Where(pc => pc.ProductId == productId)
                .Select(pc => pc.Color)
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetProductCategoriesAsync(int productId)
        {
            return await _context.ProductCategories
                .Where(pc => pc.ProductId == productId)
                .Select(pc => pc.Category)
                .ToListAsync();
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

        public async Task AddProductCategoryAsync(int productId, int categoryId)
        {
            var productCategory = new ProductCategory
            {
                ProductId = productId,
                CategoryId = categoryId
            };

            await _context.ProductCategories.AddAsync(productCategory);
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

        public async Task RemoveProductCategoryAsync(int productId, int categoryId)
        {
            var productCategory = await _context.ProductCategories
                .FirstOrDefaultAsync(pc => pc.ProductId == productId && pc.CategoryId == categoryId);

            if (productCategory != null)
            {
                _context.ProductCategories.Remove(productCategory);
            }
        }

        public override async Task AddAsync(Product product)
        {
            // Set automatic dates
            product.CreationDate = DateTime.Now;
            product.LastModificationDate = DateTime.Now;
            await base.AddAsync(product);
        }

        public override void Update(Product product)
        {
            // Update modification date
            product.LastModificationDate = DateTime.Now;
            base.Update(product);
        }
    }
}
