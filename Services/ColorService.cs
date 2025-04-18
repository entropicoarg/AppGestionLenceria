using Data.UOW;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ColorService : IColorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ColorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Color>> GetAllAsync()
        {
            return await _unitOfWork.Colors.GetAllAsync();
        }

        public async Task<Color> GetByIdAsync(int id)
        {
            return await _unitOfWork.Colors.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsByColorAsync(int colorId)
        {
            return await _unitOfWork.Colors.GetProductsByColorAsync(colorId);
        }

        public async Task<Color> CreateAsync(Color color)
        {
            await _unitOfWork.Colors.AddAsync(color);
            await _unitOfWork.CompleteAsync();

            return color;
        }

        public async Task UpdateAsync(Color color)
        {
            var existingColor = await _unitOfWork.Colors.GetByIdAsync(color.Id);

            if (existingColor == null)
                throw new KeyNotFoundException($"Color with ID {color.Id} not found.");

            _unitOfWork.Colors.Update(color);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var color = await _unitOfWork.Colors.GetByIdAsync(id);

            if (color == null)
                throw new KeyNotFoundException($"Color with ID {id} not found.");

            _unitOfWork.Colors.Delete(color);
            await _unitOfWork.CompleteAsync();
        }

        //public async Task AddProductColorAsync(int productId, int colorId)
        //{
        //    await _unitOfWork.Colors.AddAsync(productId, colorId);
        //    await _unitOfWork.CompleteAsync();
        //}

        //public async Task RemoveProductColorAsync(int productId, int colorId)
        //{
        //    await _unitOfWork.Colors.RemoveProductColorAsync(productId, colorId);
        //    await _unitOfWork.CompleteAsync();
        //}
    }
}
