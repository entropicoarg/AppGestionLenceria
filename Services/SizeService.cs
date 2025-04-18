using Data.UOW;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SizeService : ISizeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SizeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Size>> GetAllAsync()
        {
            return await _unitOfWork.Sizes.GetAllAsync();
        }

        public async Task<Size> GetByIdAsync(int id)
        {
            return await _unitOfWork.Sizes.GetByIdAsync(id);
        }

        public async Task<Size> CreateAsync(Size size)
        {
            await _unitOfWork.Sizes.AddAsync(size);
            await _unitOfWork.CompleteAsync();

            return size;
        }

        public async Task UpdateAsync(Size size)
        {
            var existingSize = await _unitOfWork.Sizes.GetByIdAsync(size.Id);

            if (existingSize == null)
                throw new KeyNotFoundException($"Size with ID {size.Id} not found.");

            _unitOfWork.Sizes.Update(size);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var size = await _unitOfWork.Sizes.GetByIdAsync(id);

            if (size == null)
                throw new KeyNotFoundException($"Size with ID {id} not found.");

            _unitOfWork.Sizes.Delete(size);
            await _unitOfWork.CompleteAsync();
        }
    }
}
