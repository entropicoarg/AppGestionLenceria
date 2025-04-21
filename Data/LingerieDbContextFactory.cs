using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Configuration;
using System.IO;

namespace Data
{
    public  class LingerieDbContextFactory : IDesignTimeDbContextFactory<LingerieDbContext>
    {
        public LingerieDbContext CreateDbContext(string[] args)
        {
            // Get the connection string from App.config
            // This won't work directly with ConfigurationManager, so we'll hardcode it for migrations
            var connectionString = "Data Source=C:\\Users\\Usuario\\Documents\\Cursos Net\\AppGestionLenceria\\DB\\LingerieDB.db";

            var optionsBuilder = new DbContextOptionsBuilder<LingerieDbContext>();
            optionsBuilder.UseSqlite(connectionString);

            return new LingerieDbContext(optionsBuilder.Options);
        }
    }
}
