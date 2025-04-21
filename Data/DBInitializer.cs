using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Data.Context;
using Data.Repositories;
using Data.UOW;



namespace Data
{
    public static class DbInitializer
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            // Configure SQLite
            services.AddDbContext<LingerieDbContext>(options =>
                options.UseSqlite(connectionString));

            // Register services
            RegisterRepositories(services);
        }

        public static void Initialize(LingerieDbContext context)
        {
            // Ensure database exists and is created
            //context.Database.EnsureCreated();

            // Apply migrations instead of EnsureCreated
            context.Database.Migrate();

            // Here you can add seed data if needed
            // SeedData(context);
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            // Register repositories
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductColorRepository, ProductColorRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ISaleDetailRepository, SaleDetailRepository>();

            // Register UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

