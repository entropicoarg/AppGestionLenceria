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
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(LingerieDbContext context) : base(context)
        {
        }

        public async Task<Supplier> GetWithProductsAsync(int id)
        {
            return await _context.Suppliers
                .Include(p => p.Products)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
