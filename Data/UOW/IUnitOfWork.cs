using Data.Context;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        ISupplierRepository Suppliers { get; }
        IColorRepository Colors { get; }
        ISizeRepository Sizes { get; }
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        IProductColorRepository ProductColors { get; }
        IProductCategoryRepository ProductCategories { get; }
        ICustomerRepository Customers { get; }
        ISaleRepository Sales { get; }
        ISaleDetailRepository SaleDetails { get; }

        Task<int> CompleteAsync();
    }    
}
