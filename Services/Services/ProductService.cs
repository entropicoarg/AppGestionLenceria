using Data.UOW;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _unitOfWork.Products.GetByIdAsync(id);
        }

        public async Task<Product> GetWithAllRelationsAsync(int id)
        {
            return await _unitOfWork.Products.GetWithAllRelationsAsync(id);
        }

        public async Task<IEnumerable<Product>> GetBySupplierAsync(int supplierId)
        {
            return await _unitOfWork.Products.GetBySupplierAsync(supplierId);
        }

        public async Task<IEnumerable<Color>> GetProductColorsAsync(int productId)
        {
            return await _unitOfWork.Products.GetProductColorsAsync(productId);
        }

        public async Task<IEnumerable<Category>> GetProductCategoriesAsync(int productId)
        {
            return await _unitOfWork.Products.GetProductCategoriesAsync(productId);
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.CompleteAsync();

            return product;
        }

        public async Task UpdateAsync(Product product)
        {
            var existingProduct = await _unitOfWork.Products.GetByIdAsync(product.Id);

            if (existingProduct == null)
                throw new KeyNotFoundException($"Product with ID {product.Id} not found.");

            // Preserve creation date
            product.CreationDate = existingProduct.CreationDate;

            _unitOfWork.Products.Update(product);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
                throw new KeyNotFoundException($"Product with ID {id} not found.");

            _unitOfWork.Products.Delete(product);
            await _unitOfWork.CompleteAsync();
        }
    }
}
