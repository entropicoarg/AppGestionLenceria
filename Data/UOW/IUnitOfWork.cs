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

    public class UnitOfWork : IUnitOfWork
    {
        private readonly LingerieDbContext _context;

        public ISupplierRepository Suppliers { get; }
        public IColorRepository Colors { get; }
        public ISizeRepository Sizes { get; }
        public ICategoryRepository Categories { get; }
        public IProductRepository Products { get; }
        public IProductColorRepository ProductColors { get; }
        public IProductCategoryRepository ProductCategories { get; }
        public ICustomerRepository Customers { get; }
        public ISaleRepository Sales { get; }
        public ISaleDetailRepository SaleDetails { get; }

        public UnitOfWork(
            LingerieDbContext context,
            ISupplierRepository supplierRepository,
            IColorRepository colorRepository,
            ISizeRepository sizeRepository,
            ICategoryRepository categoryRepository,
            IProductRepository productRepository,
            IProductColorRepository productColorRepository,
            IProductCategoryRepository productCategoryRepository,
            ICustomerRepository customerRepository,
            ISaleRepository saleRepository,
            ISaleDetailRepository saleDetailRepository)
        {
            _context = context;
            Suppliers = supplierRepository;
            Colors = colorRepository;
            Sizes = sizeRepository;
            Categories = categoryRepository;
            Products = productRepository;
            ProductColors = productColorRepository;
            ProductCategories = productCategoryRepository;
            Customers = customerRepository;
            Sales = saleRepository;
            SaleDetails = saleDetailRepository;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
