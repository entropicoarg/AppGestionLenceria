using Data.UOW;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _unitOfWork.Categories.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _unitOfWork.Categories.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _unitOfWork.Categories.GetProductsByCategoryAsync(categoryId);
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.CompleteAsync();

            return category;
        }

        public async Task UpdateAsync(Category category)
        {
            var existingCategory = await _unitOfWork.Categories.GetByIdAsync(category.Id);

            if (existingCategory == null)
                throw new KeyNotFoundException($"Category with ID {category.Id} not found.");

            existingCategory.Name = category.Name;            

            _unitOfWork.Categories.Update(existingCategory);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);

            if (category == null)
                throw new KeyNotFoundException($"Category with ID {id} not found.");

            _unitOfWork.Categories.Delete(category);
            await _unitOfWork.CompleteAsync();
        }

        public async Task AddProductCategoryAsync(int productId, int categoryId)
        {
            await _unitOfWork.Categories.AddProductCategoryAsync(productId, categoryId);
            await _unitOfWork.CompleteAsync();
        }

        public async Task RemoveProductCategoryAsync(int productId, int categoryId)
        {
            await _unitOfWork.Categories.RemoveProductCategoryAsync(productId, categoryId);
            await _unitOfWork.CompleteAsync();
        }
    }
}
