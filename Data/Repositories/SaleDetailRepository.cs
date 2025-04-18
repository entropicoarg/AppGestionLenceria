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
    public class SaleDetailRepository : GenericRepository<SaleDetail>, ISaleDetailRepository
    {
        public SaleDetailRepository(LingerieDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<SaleDetail>> GetBySaleAsync(int saleId)
        {
            return await _context.SaleDetails
                .Include(d => d.Product)
                .Where(d => d.SaleId == saleId)
                .ToListAsync();
        }

        public async Task<IEnumerable<SaleDetail>> GetByProductAsync(int productId)
        {
            return await _context.SaleDetails
                .Include(d => d.Sale)
                .Where(d => d.ProductId == productId)
                .ToListAsync();
        }
    }
}
