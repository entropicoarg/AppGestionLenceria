using Data.UOW;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return await _unitOfWork.Suppliers.GetAllAsync();
        }

        public async Task<Supplier> GetByIdAsync(int id)
        {
            return await _unitOfWork.Suppliers.GetByIdAsync(id);
        }

        public async Task<Supplier> GetWithProductsAsync(int id)
        {
            return await _unitOfWork.Suppliers.GetWithProductsAsync(id);
        }

        public async Task<Supplier> CreateAsync(Supplier supplier)
        {
            supplier.CreationDate = DateTime.Now;
            supplier.LastModificationDate = DateTime.Now;

            await _unitOfWork.Suppliers.AddAsync(supplier);
            await _unitOfWork.CompleteAsync();

            return supplier;
        }

        public async Task UpdateAsync(Supplier supplier)
        {
            var existingSupplier = await _unitOfWork.Suppliers.GetByIdAsync(supplier.Id);

            if (existingSupplier == null)
                throw new KeyNotFoundException($"Supplier with ID {supplier.Id} not found.");

            existingSupplier.Name = supplier.Name;
            existingSupplier.LastModificationDate = DateTime.Now;

            _unitOfWork.Suppliers.Update(existingSupplier);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var supplier = await _unitOfWork.Suppliers.GetByIdAsync(id);

            if (supplier == null)
                throw new KeyNotFoundException($"Supplier with ID {id} not found.");

            _unitOfWork.Suppliers.Delete(supplier);
            await _unitOfWork.CompleteAsync();
        }
    }
}
