using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
    

namespace Services.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<ISizeService, SizeService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPrintService, PrintService>();

            var configuration = BuildConfiguration();
            services.AddSingleton<IConfiguration>(configuration);

            // Register new print configuration service
            services.AddSingleton<IPrintConfigurationService, PrintConfigurationService>();

            // Register print service

            return services;
        }

        private static IConfiguration BuildConfiguration()
        {
            // Get the base directory of the application
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Build configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(baseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            // If there's a specific environment setting, you could add it here
            // For example: .AddJsonFile($"appsettings.{environment}.json", optional: true)

            return builder.Build();
        }
    }
}
