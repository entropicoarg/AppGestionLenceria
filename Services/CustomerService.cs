using Data.UOW;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _unitOfWork.Customers.GetAllAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _unitOfWork.Customers.GetByIdAsync(id);
        }

        public async Task<Customer> GetWithSalesAsync(int id)
        {
            return await _unitOfWork.Customers.GetWithSalesAsync(id);
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            await _unitOfWork.Customers.AddAsync(customer);
            await _unitOfWork.CompleteAsync();

            return customer;
        }

        public async Task UpdateAsync(Customer customer)
        {
            var existingCustomer = await _unitOfWork.Customers.GetByIdAsync(customer.Id);

            if (existingCustomer == null)
                throw new KeyNotFoundException($"Customer with ID {customer.Id} not found.");

            _unitOfWork.Customers.Update(customer);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);

            if (customer == null)
                throw new KeyNotFoundException($"Customer with ID {id} not found.");

            _unitOfWork.Customers.Delete(customer);
            await _unitOfWork.CompleteAsync();
        }
    }
}
