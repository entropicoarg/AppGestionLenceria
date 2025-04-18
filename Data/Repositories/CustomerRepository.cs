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
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(LingerieDbContext context) : base(context)
        {
        }

        public async Task<Customer> GetWithSalesAsync(int id)
        {
            return await _context.Customers
                .Include(c => c.Sales)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
