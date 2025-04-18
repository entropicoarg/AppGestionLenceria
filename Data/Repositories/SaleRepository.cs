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
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        public SaleRepository(LingerieDbContext context) : base(context)
        {
        }

        public async Task<Sale> GetWithDetailsAsync(int id)
        {
            return await _context.Sales
                .Include(v => v.Customer)
                .Include(v => v.SaleDetails)
                .ThenInclude(d => d.Product)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<Sale>> GetByCustomerAsync(int customerId)
        {
            return await _context.Sales
                .Where(v => v.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Sale>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Sales
                .Where(v => v.SaleDate >= startDate && v.SaleDate <= endDate)
                .ToListAsync();
        }

        public override async Task AddAsync(Sale sale)
        {
            // Set sale date if not defined
            if (sale.SaleDate == default)
            {
                sale.SaleDate = DateTime.Now;
            }

            await base.AddAsync(sale);
        }
    }
}
