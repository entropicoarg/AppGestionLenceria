using Data.UOW;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SaleService : ISaleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SaleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Sale>> GetAllAsync()
        {
            return await _unitOfWork.Sales.GetAllAsync();
        }

        public async Task<Sale> GetByIdAsync(int id)
        {
            return await _unitOfWork.Sales.GetByIdAsync(id);
        }

        public async Task<Sale> GetWithDetailsAsync(int id)
        {
            return await _unitOfWork.Sales.GetWithDetailsAsync(id);
        }

        public async Task<IEnumerable<Sale>> GetByCustomerAsync(int customerId)
        {
            return await _unitOfWork.Sales.GetByCustomerAsync(customerId);
        }

        public async Task<IEnumerable<Sale>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _unitOfWork.Sales.GetByDateRangeAsync(startDate, endDate);
        }
        public async Task UpdateAsync(Sale sale)
        {
            var existingSale = await _unitOfWork.Sales.GetByIdAsync(sale.Id);

            if (existingSale == null)
                throw new KeyNotFoundException($"Sale with ID {sale.Id} not found.");

            _unitOfWork.Sales.Update(sale);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<Sale> CreateAsync(Sale sale, IEnumerable<SaleDetail> details)
        {
            // Set sale date if not set
            if (sale.SaleDate == default)
            {
                sale.SaleDate = DateTime.Now;
            }

            // Calculate total price
            decimal totalPrice = 0;

            // Begin transaction
            try
            {
                // Add sale first
                await _unitOfWork.Sales.AddAsync(sale);
                await _unitOfWork.CompleteAsync();

                // Add details with the new sale ID
                foreach (var detail in details)
                {
                    detail.SaleId = sale.Id;

                    // Get product information for price calculation
                    var product = await _unitOfWork.Products.GetByIdAsync(detail.ProductId);
                    if (product != null)
                    {
                        detail.UnitPrice = product.RoundedPrice;
                        totalPrice += detail.Subtotal;

                        // Update product inventory
                        product.Quantity -= detail.Quantity;
                        _unitOfWork.Products.Update(product);
                    }

                    await _unitOfWork.SaleDetails.AddAsync(detail);
                }

                // Update sale with calculated total price
                sale.TotalPrice = totalPrice;
                _unitOfWork.Sales.Update(sale);

                await _unitOfWork.CompleteAsync();

                return sale;
            }
            catch (Exception)
            {
                // Transaction should be rolled back by the Unit of Work
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var sale = await _unitOfWork.Sales.GetWithDetailsAsync(id);

            if (sale == null)
                throw new KeyNotFoundException($"Sale with ID {id} not found.");

            // Restore product inventory
            foreach (var detail in sale.SaleDetails)
            {
                var product = await _unitOfWork.Products.GetByIdAsync(detail.ProductId);
                if (product != null)
                {
                    product.Quantity += detail.Quantity;
                    _unitOfWork.Products.Update(product);
                }
            }

            _unitOfWork.Sales.Delete(sale);
            await _unitOfWork.CompleteAsync();
        }

    }
}
