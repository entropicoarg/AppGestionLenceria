using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    // Specific interfaces for each entity
    public interface ISupplierRepository : IGenericRepository<Supplier>
    {
        Task<Supplier> GetWithProductsAsync(int id);
    }
}
