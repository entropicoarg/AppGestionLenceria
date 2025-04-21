using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Data;
using Services.Services;
using Data.Context;



namespace AppGestionLenceria
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        
        public static IServiceProvider ServiceProvider { get; private set; }
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.            

            //Configure services
            var services = new ServiceCollection();

            //Add app services
            services.AddApplicationServices();

            //Configure database
            string connectionString = ConfigurationManager.ConnectionStrings["SQLiteDBConnection"].ConnectionString;
            DbInitializer.ConfigureServices(services, connectionString);

            //Build service provider
            ServiceProvider = services.BuildServiceProvider();

            //initialize DB
            using(var scope = ServiceProvider.CreateScope())
            {
                var dbContext  = scope.ServiceProvider.GetRequiredService<LingerieDbContext>();
                DbInitializer.Initialize(dbContext);
            }

            
            
            //Initialice app
            ApplicationConfiguration.Initialize();
            Application.Run(new ProductManagementForm(ServiceProvider));
        }
    }
}